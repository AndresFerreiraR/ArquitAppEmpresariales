
namespace Pacagroup.Ecommerce.Services.WebApi
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Application.Main;
    using Pacagroup.Ecommerce.Domain.Core;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Data;
    using Pacagroup.Ecommerce.Infraestructure.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Repository;
    using Pacagroup.Ecommerce.Services.WebApi.Helpers;
    using Pacagroup.Ecommerce.Transversal.Common;
    using Pacagroup.Ecommerce.Transversal.Logging;
    using Pacagroup.Ecommerce.Transversal.Mapper;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.OpenApi.Models;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;

    public class Startup
    {

        private readonly string myPolicy = "policyApiEcomerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();
            // CORS
            services.AddFeacture(this.Configuration);
            // Instancia del IConfiguration para traer el appsettings.Json
            // Inyecion de dependencias de las interfaces y clases que las implementan
            services.AddInjection(this.Configuration);
            // Agregar autenticacion al API
            services.AddAuthentication(this.Configuration);
            // Configuracion Swagger
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API ECommerce V1");
            });
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
