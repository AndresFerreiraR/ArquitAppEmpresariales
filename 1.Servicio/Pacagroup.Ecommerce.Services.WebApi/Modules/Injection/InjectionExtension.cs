
namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Injection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pacagroup.Ecommerce.Application.Interface;
    using Pacagroup.Ecommerce.Application.Main;
    using Pacagroup.Ecommerce.Domain.Core;
    using Pacagroup.Ecommerce.Domain.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Data;
    using Pacagroup.Ecommerce.Infraestructure.Interface;
    using Pacagroup.Ecommerce.Infraestructure.Repository;
    using Pacagroup.Ecommerce.Transversal.Common;
    using Pacagroup.Ecommerce.Transversal.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public static class InjectionExtension
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
