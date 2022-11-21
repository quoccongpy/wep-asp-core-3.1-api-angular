using AutoMapper;
using ShopAngular.Model.Entities;
using ShopAngular.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAngular.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(a=>a.ProductBrand,b=>b.MapFrom(c=>c.ProductBrand.Name))
                .ForMember(a=>a.ProductType,b=>b.MapFrom(c=>c.ProductType.Name))
                .ForMember(a=>a.PictureUrl,b=>b.MapFrom<ProductUrlResolver>());
        }
    }
}
