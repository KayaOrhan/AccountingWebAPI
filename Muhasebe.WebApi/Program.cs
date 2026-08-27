using Microsoft.EntityFrameworkCore;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;
using Muhasebe.Persistance.Context;
using Muhasebe.Persistance.Services.AppService;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();



builder.Services.AddOpenApi();

builder.Services.AddControllers().AddApplicationPart(typeof(Muhasebe.Presentation.AssemblyReference).Assembly);

builder.Services.AddScoped<ICompanyService, CompanyService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Muhasebe.Application.AssemblyReference).Assembly));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Benim Harika API Dokümanım")
            .WithTheme(ScalarTheme.BluePlanet)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient); // C# için hazır kod örnekleri sunar
    });
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
