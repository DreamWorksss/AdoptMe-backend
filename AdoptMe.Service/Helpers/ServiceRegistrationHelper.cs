using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Service.Helpers
{
    public static class ServiceRegistrationHelper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //here you add your custom services like that: services.AddScoped<Interface, Implementation>();
            return services;
        }
    }
}
