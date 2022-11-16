using SpaceFork.eShop.Catalog.Core;
using SpaceFork.eShop.Catalog.Core.Dto;
using SpaceFork.eShop.Catalog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Catalog.Application.AutoMapperProfile
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

        }
    }
}
