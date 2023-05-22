using TextAnalysis.Application;
using TextAnalysis.Infrastructure;
using TextAnalysis.Web;

var builder = WebApplication.CreateBuilder(args);


string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

builder.Services
    .AddWeb()
    .AddApplication()
    .AddInfrastructure(builder.Environment.EnvironmentName == "Development", connectionString!)
    .AddDomain();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}