using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service.Helpers
{
    public static class ServiceRegistrationHelper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IShelterService, ShelterService>();
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IAdoptionRequestService, AdoptionRequestService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAdoptionAtDistanceService, AdoptionAtDistanceService>();
            return services;
        }
    }
}
