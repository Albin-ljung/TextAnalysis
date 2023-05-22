using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TextAnalysis.Domain.Interfaces;
using TextAnalysis.Infrastructure.Data;
using TextAnalysis.Infrastructure.Interfaces;

namespace TextAnalysis.Infrastructure;
public static class StartupSetup
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        bool isDevelopment,
        string connectionString)
    {

        if (isDevelopment)
        {
            RegisterDevelopmentDependencies(services);
        }
        else
        {
            RegisterProductionDependencies(services);
        }

        RegisterCommonDependencies(services, connectionString);

        return services;
    }
    private static void RegisterCommonDependencies(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TextAnalysisDBContext>(options =>
        options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    }
    private static void RegisterDevelopmentDependencies(IServiceCollection services) { }
    private static void RegisterProductionDependencies(IServiceCollection services) { }
}

