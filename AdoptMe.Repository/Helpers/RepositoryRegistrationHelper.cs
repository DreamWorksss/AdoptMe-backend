﻿using AdoptMe.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Repository.Helpers
{
    public static class RepositoryRegistrationHelper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IShelterRepository, ShelterRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IAdoptionAtDistanceRepository, AdoptionAtDistanceRepository>();
            services.AddScoped<IAdoptionRequestRepository, AdoptionRequestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
