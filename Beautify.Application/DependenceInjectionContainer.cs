
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Beautify.Application;

public static class DependenceInjectionContainer
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
