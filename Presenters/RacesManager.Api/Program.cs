using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;
using RacesManager.Adapters.Persistence.InMemory.Repositories;
using RacesManager.Api.Data;
using RacesManager.Api.Responses;
using RacesManager.Application.Ports;
using RacesManager.Application.UseCases.GetRaceEvents;


namespace RacesManager.Api;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IRacesRepository>(_ => new InMemoryIRaceRepositoryRepository().FillData());
        builder.Services.AddScoped<IGetRaceIcsCalendarUseCase, GetRaceIcsCalendarUseCase>();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "RacesManager.Api",
                Version = "",
                Description = "This API provide services for F1 and MotoGP fan.",
                License = new OpenApiLicense{Name = "MIT License", Url = new Uri("https://choosealicense.com/licenses/mit/")},
                Contact = new OpenApiContact
                {
                    Name = "Romain Bourré",
                    Url = new Uri("https://romainbourre.fr"),
                    Email = "contact@romainbourre.fr",
                },
            });
        });

        WebApplication app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RacesManager.Api"));
        
        app.MapGet("/", () => Results.Extensions.Html(@"<!doctype html>
<html>
    <head>
        <meta charset=""utf-8"">
        <title>🏁 Race Manager</title>
        <link rel=""stylesheet"" href=""https://unpkg.com/@picocss/pico@latest/css/pico.min.css"">
    </head>
    <body>
        <main>
            <h1>🏁Race Manager</h1>
            <p>This API provide services for F1 and MotoGP fan:</p>
            <ul>
                <li style=""list-style-type: none;"">📜 <a target=""_blank"" href=""/swagger"">Go to API documentation</a></li>
                <li style=""list-style-type: none;"">🗓 <a target=""_blank"" href=""/calendar"">Subscribe to Formula 1 and Moto Gp calendar</a></li>
            </ul>
        </main>
        <footer>
            <p>Any idea? Any bug? Please <a target=""_blank"" href=""https://myfeedbacks.fr/en/projects/f1964b71-f6dd-4b24-908f-cd5838960750"">give us feedbacks!</a>
            <p>Made with ❤️ by <a target=""_blank"" href=""https://romainbourre.fr"">Romain Bourré</a></p>
        </footer>
    </body>
</html>"));

        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.Run();
    }
}