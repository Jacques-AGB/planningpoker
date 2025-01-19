using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using planningpoker.Application.Features.Roles.Commands;
using planningpoker.Application.IRepository;
using planningpoker.Domain.IRepository;
using planningpoker.Infrastructure.Persistence.PostgreSql;
using planningpoker.Infrastructure.Repository;

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


        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRuleRepository, RuleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVoteRepository, VoteRepository>();

        return services;
    }

}
