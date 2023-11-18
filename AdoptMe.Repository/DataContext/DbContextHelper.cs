using AdoptMe.Common.DatabaseConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Repository.DataContext
{
    public static class DbContextHelper
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdoptMeDbContext>(opts =>
            {
                var connectionString = configuration.GetConnectionString(ConnectionConstants.ConnectionString);
                opts.UseNpgsql(connectionString);
            });
            return services;
        }
    }
}
