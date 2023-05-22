using Microsoft.Extensions.DependencyInjection;

namespace TextAnalysis.Application
{
    public static class StartupSetup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IIssueSearchService, IssueSearchService>();
            return services;
        }
    }
}
