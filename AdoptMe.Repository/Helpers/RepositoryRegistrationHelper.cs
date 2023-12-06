using AdoptMe.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Repository.Helpers
{
    public static class RepositoryRegistrationHelper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IShelterRepository, ShelterRepository>();
            return services;
        }
    }
}
