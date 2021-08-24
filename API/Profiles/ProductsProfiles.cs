using API.DTOs;
using API.DTOs.ProductsDtos;
using API.Models.ProductModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductsGroupFirst, ProductsGroupFirstDto>();
            CreateMap<ProductsGroupSecond, ProductsGroupSecondDto>();
            CreateMap<ProductsGroupThird, ProductsGroupThirdDto>();
        }
    }
}
