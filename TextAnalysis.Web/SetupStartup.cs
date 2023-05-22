using FluentValidation;
using System.Reflection;

namespace TextAnalysis.Web
{
    public static class StartupSetup
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();

            return services;
        }
    }
}
