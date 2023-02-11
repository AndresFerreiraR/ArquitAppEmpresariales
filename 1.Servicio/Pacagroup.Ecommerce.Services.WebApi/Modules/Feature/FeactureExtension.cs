
namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Feature
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public static class FeactureExtension
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeacture(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcomerce";

            services.AddCors(opt =>
                             opt.AddPolicy(myPolicy, bld =>
                                                     bld.WithOrigins(configuration["Config:OriginCors"])
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            return services;
        }
    }
}
