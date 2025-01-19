using MediatR.NotificationPublishers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace planningpoker.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.NotificationPublisher = new TaskWhenAllPublisher();
        });

        return services;
    }
}
