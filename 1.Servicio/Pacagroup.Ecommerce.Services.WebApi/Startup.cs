
namespace Pacagroup.Ecommerce.Services.WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
    using Pacagroup.Ecommerce.Services.WebApi.Modules.Validator;

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

            services.AddValidator();
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
