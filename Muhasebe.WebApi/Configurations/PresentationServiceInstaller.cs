using Microsoft.OpenApi;

namespace Muhasebe.WebApi.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddApplicationPart(typeof(Muhasebe.Presentation.AssemblyReference).Assembly);

            services.AddOpenApi(options =>
            {
                // Adds JWT Bearer security scheme to the OpenAPI document
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    var scheme = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer", // Must be lowercase 'bearer'
                        BearerFormat = "JWT",
                        Description = "Enter your JWT token here (Do not include 'Bearer' prefix)."
                    };

                    document.Components ??= new OpenApiComponents();
                    document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
                    document.Components.SecuritySchemes.Add("Bearer", scheme);

                    return Task.CompletedTask;
                });
            });

        }

    }
}
