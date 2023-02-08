
namespace Pacagroup.Ecommerce.Services.WebApi
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Application.Main;
    using Pacagroup.Ecommerce.Domain.Core;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Data;
    using Pacagroup.Ecommerce.Infraestructure.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Repository;
    using Pacagroup.Ecommerce.Transversal.Common;
    using Pacagroup.Ecommerce.Transversal.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver(); });

            // Instancia del IConfiguration para traer el appsettings.Json
            services.AddSingleton<IConfiguration>(Configuration);

            // Inyecion de dependencias de las interfaces y clases que las implementan
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
