using Beautify.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beautify.PersistenceDb;

public static class DependencyInjectionContainer
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<BeautifyDbContext>(options => 
                options.UseSqlServer(connectionString));

        services.AddScoped<IBeautifyDbContext>(provider =>
                provider.GetService<BeautifyDbContext>());

        return services;
    }
}
