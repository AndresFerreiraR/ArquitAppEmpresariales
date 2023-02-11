using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Transversal.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper
{
    public static class MapperExtension
    {

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
