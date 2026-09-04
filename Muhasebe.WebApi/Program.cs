using Muhasebe.WebApi.Configurations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesInAssembly(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("My Glorious API")
            .WithTheme(ScalarTheme.BluePlanet)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient); // C# için hazır kod örnekleri sunar
    });
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
