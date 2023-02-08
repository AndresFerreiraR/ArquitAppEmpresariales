
namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    using AutoMapper;
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Domain.Entity;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class MappingsProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
        }
    }
}
