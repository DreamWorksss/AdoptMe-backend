using AdoptMe.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service.Helpers
{
    public static class ServiceRegistrationHelper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            return services;
        }
    }
}
