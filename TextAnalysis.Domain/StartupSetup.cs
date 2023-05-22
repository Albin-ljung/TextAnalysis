using Microsoft.Extensions.DependencyInjection;
public static class StartupSetup
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}