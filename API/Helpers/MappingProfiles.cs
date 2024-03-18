using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductsToReturn>()
            .ForMember(b=> b.ProductBrand,o=> o.MapFrom(m=> m.ProductBrand.Name))
            .ForMember(b=> b.ProductType,o=> o.MapFrom(m=> m.ProductType.Name))
            .ForMember(b=> b.PictureUrl,o=> o.MapFrom<ProductUrl>());
        }
    }
}