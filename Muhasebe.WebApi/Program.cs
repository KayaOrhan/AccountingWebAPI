using Microsoft.EntityFrameworkCore;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Application.Services.CompanyServices;
using Muhasebe.Domain;
using Muhasebe.Domain.AppEntities.Identity;
using Muhasebe.Domain.Repositories.UCAFRepositories;
using Muhasebe.Persistance;
using Muhasebe.Persistance.Context;
using Muhasebe.Persistance.Repositories.UCAFRepositories;
using Muhasebe.Persistance.Services.AppService;
using Muhasebe.Persistance.Services.CompanyService;
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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
builder.Services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
builder.Services.AddScoped<IUCAFService, UCAFService>();
builder.Services.AddScoped<IContextService, ContextService>();


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
