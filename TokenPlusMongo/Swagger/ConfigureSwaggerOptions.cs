using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TokenPlusMongo.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Scheme = "Bearer",
            });
        }
    }
}
