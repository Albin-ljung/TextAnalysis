using TextAnalysis.Application;
using TextAnalysis.Infrastructure;
using TextAnalysis.Web;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

builder.Services
    .AddWeb()
    .AddApplication()
    .AddInfrastructure(builder.Environment.EnvironmentName == "Development", connectionString!);
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
