using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdoptMe.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
        }

        public string GenerateToken(int userId, string userRole, int shelterId)
        {
            var tokenSettings = _configuration.GetRequiredSection(ServerConstants.Token);
            if (!IsConfigurationValid(tokenSettings))
            {
                throw new FileLoadException("There is no authorization token configuration!");
            }

            int.TryParse(tokenSettings[ServerConstants.ExpirationTime], out var expirationTime);
            var token = new JwtSecurityToken
            (
                issuer: tokenSettings[ServerConstants.Issuer],
                audience: tokenSettings[ServerConstants.Audience],
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Role, userRole),
                    new Claim(ClaimTypes.GroupSid, shelterId.ToString())
                },
                expires: DateTime.UtcNow.AddMinutes(expirationTime),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings[ServerConstants.SecretKey]!)), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenValidatorResult ValidateToken(string token)
        {
            var tokenSettings = _configuration.GetRequiredSection(ServerConstants.Token);
            if (tokenSettings == null || !IsConfigurationValid(tokenSettings))
            {
                throw new FileLoadException("There is no authorization token configuration!");
            }
            var validationParameters = BuildTokenValidationParameters(tokenSettings);
            return BuildTokenValidatorResult(new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out _));
        }

        public static bool IsConfigurationValid(IConfigurationSection configuration)
        {
            return configuration != null && int.TryParse(configuration[ServerConstants.ExpirationTime], out _) && !string.IsNullOrEmpty(configuration[ServerConstants.Issuer])
                && !string.IsNullOrEmpty(configuration[ServerConstants.Audience]) && !string.IsNullOrEmpty(configuration[ServerConstants.SecretKey]);
        }

        public static TokenValidationParameters BuildTokenValidationParameters(IConfigurationSection tokenSettings)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings[ServerConstants.SecretKey]!));
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tokenSettings[ServerConstants.Issuer],
                ValidAudience = tokenSettings[ServerConstants.Audience],
                IssuerSigningKey = key,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromTicks(TimeSpan.TicksPerMinute * 5)
            };
            return validationParameters;
        }

        private TokenValidatorResult BuildTokenValidatorResult(ClaimsPrincipal claims)
        {
            var userRole = claims.FindFirst(ClaimTypes.Role)?.Value;
            if (!int.TryParse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
                || !int.TryParse(claims.FindFirst(ClaimTypes.GroupSid)?.Value, out var shelterId)
                || userRole == null)
            {
                throw new SecurityTokenValidationException("Could not validate the token!");
            }

            return new TokenValidatorResult
            {
                UserId = userId,
                ShelterId = shelterId,
                UserRole = userRole
            };
        }
    }
}
