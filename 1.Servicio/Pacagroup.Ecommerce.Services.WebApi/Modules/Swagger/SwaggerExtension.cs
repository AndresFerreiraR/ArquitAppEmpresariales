
namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pacagroup Technology Service API Market",
                    Description = "A simple example .Net Core Project with DDD",
                    TermsOfService = new Uri("https://example.com/license"),
                    Contact = new OpenApiContact
                    {
                        Email = "ac.ferreira.r@gmail.com",
                        Name = "Andres Ferreira",
                        Url = new Uri("https://github.com/AndresFerreiraR/ArquitAppEmpresariales.git")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "IMIT",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            return services;
        }
    }
}
