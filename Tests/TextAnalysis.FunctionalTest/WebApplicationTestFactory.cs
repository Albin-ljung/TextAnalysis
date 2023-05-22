using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TextAnalysis.Infrastructure.Data;

namespace TextAnalysis.FunctionalTest
{
    public class WebApplicationTestFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Development"); // will not send real emails
            var host = builder.Build();
            host.Start();

            // Get service provider.
            var serviceProvider = host.Services;

            // Create a scope to obtain a reference to the database
            // context (AppDbContext).
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TextAnalysisDBContext>();

                var logger = scopedServices
                    .GetRequiredService<ILogger<WebApplicationTestFactory<TProgram>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();
            }

            return host;
        }
    }
}
