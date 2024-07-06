using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ResultPattern.Application;
public static class ServiceConfig
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
