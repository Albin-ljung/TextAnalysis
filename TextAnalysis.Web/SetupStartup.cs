using FluentValidation;
using System.Reflection;

namespace TextAnalysis.Web
{
    public static class StartupSetup
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
