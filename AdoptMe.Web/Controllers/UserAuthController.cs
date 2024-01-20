using AdoptMe.Common.CommonConstants;
using AdoptMe.Repository.Models;
using AdoptMe.Service.Interfaces;
using AdoptMe.Web.ExceptionHandling;
using AdoptMe.Web.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAuthController(IServiceProvider serviceProvider)
        {
            _tokenService = serviceProvider.GetRequiredService<ITokenService>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        [HttpPost]
        [Route("api/[controller]/register")]
        public IActionResult Register([FromBody] UserRegisterModel userRegisterModel)
        {
            if(userRegisterModel != null)
            {
                var user = _userService.AddUser(_mapper.Map<User>(userRegisterModel));
                return ResponseHandler.HandleResponse(new { AuthToken = _tokenService.GenerateToken(user.Id, user.Role, user.ShelterId ?? 0) });
            }
            else
            {
                return ResponseHandler.HandleResponse(UserErrorMessages.InvalidAuthModel);
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAuthModel userAuthModel)
        {
            if (userAuthModel != null)
            {
                var user = _userService.LoginUser(userAuthModel.Username, userAuthModel.Password);
                return ResponseHandler.HandleResponse(new { AuthToken = _tokenService.GenerateToken(user.Id, user.Role, user.ShelterId ?? 0) });
            }
            else
            {
                return ResponseHandler.HandleResponse(UserErrorMessages.InvalidAuthModel);
            }
        }

        [HttpGet]
        public IActionResult RetrieveUserInfo()
        {
            var authorizationHeader = Request.Headers.Authorization;
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                return ResponseHandler.HandleResponse(new { Details = _tokenService.ValidateToken(authorizationHeader.ToString()) });
            }
            return ResponseHandler.HandleUnauthorizedResponse(ServerErrorMessages.InvalidToken);
        }
    }
}
