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
            CreateMap<Users, UsersDto>().ReverseMap();

            //CreateMap<Customers, CustomersDto>().ReverseMap()
            //    .ForMember(d => d.CustomerId, s => s.MapFrom(src => src.CustomerId))
            //    .ForMember(d => d.CompanyName, s => s.MapFrom(src => src.CompanyName))
            //    .ForMember(d => d.ContactName, s => s.MapFrom(src => src.ContactName))
            //    .ForMember(d => d.ContactTitle, s => s.MapFrom(src => src.ContactTitle))
            //    .ForMember(d => d.Address, s => s.MapFrom(src => src.Address))
            //    .ForMember(d => d.City, s => s.MapFrom(src => src.City))
            //    .ForMember(d => d.Region, s => s.MapFrom(src => src.Region))
            //    .ForMember(d => d.PostalCode, s => s.MapFrom(src => src.PostalCode))
            //    .ForMember(d => d.Country, s => s.MapFrom(src => src.Country))
            //    .ForMember(d => d.Phone, s => s.MapFrom(src => src.Phone))
            //    .ForMember(d => d.Fax, s => s.MapFrom(src => src.Fax));
        }
    }
}
