using Microsoft.Extensions.DependencyInjection;
using TextAnalysis.Application.Services;
using TextAnalysis.Domain.Interfaces;

namespace TextAnalysis.Application;
public static class StartupSetup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISentenceService, SentenceService>();
        services.AddScoped<ICommonWordService, CommonWordService>();

        return services;
    }
}

