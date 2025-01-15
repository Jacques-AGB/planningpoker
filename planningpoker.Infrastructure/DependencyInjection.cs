using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using planningpoker.Infrastructure.Persistence.PostgreSql;

namespace planningpoker.Infrastructure;
public static class DependencyInjection
{

    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<PostgreSqlApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("postgresqlConnectionString");
            options.UseNpgsql(connectionString);
        }
            
            );


        return services;
    }

}
