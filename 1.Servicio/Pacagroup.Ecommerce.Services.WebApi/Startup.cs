﻿
namespace Pacagroup.Ecommerce.Services.WebApi
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
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


    public class Startup
    {

        private string myPolicy = "policyApiEcomerce";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

            // CORS
            services.AddCors(opt =>
                             opt.AddPolicy(myPolicy, bld =>
                                                     bld.WithOrigins(Configuration["Config:OriginCors"])
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver(); });

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettigs = appSettingsSection.Get<AppSettings>();

            // Instancia del IConfiguration para traer el appsettings.Json
            services.AddSingleton<IConfiguration>(Configuration);

            // Inyecion de dependencias de las interfaces y clases que las implementan
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            var key = Encoding.ASCII.GetBytes(appSettigs.Secret);
            var issuer = appSettigs.Issuer;
            var audience = appSettigs.Audience;

            // Agregar autenticacion al API
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userId = int.Parse(context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },

                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Configuracion Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Pacagroup Technology Service API Market",
                    Description = "A simple example .Net Core Project with DDD",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Email = "ac.ferreira.r@gmail.com",
                        Name = "Andres Ferreira",
                        Url = "https://github.com/AndresFerreiraR/ArquitAppEmpresariales.git"
                    },
                    License = new License
                    {
                        Name = "IMIT",
                        Url = "https://example.com/license"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Authorization", new ApiKeyScheme
                {
                    Description = "Authorization by API key",
                    In = "header",
                    Type = "apiKey",
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Authorization", new string[0] }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API ECommerce V1");
            });
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
