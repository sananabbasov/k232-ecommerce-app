using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.Business.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryHomeDto>()
            .ForMember(x => x.ProductCount, y => y.MapFrom(x => x.Products.Count()));

        CreateMap<Category, CategoryOfferDto>()
            .ForMember(x => x.DiscountPercent, y => y.MapFrom(q => q.Products.Select(x => Math.Round(x.DiscountPrice / x.Price * 100)).FirstOrDefault()));

        CreateMap<Product, ProductHomeDto>()
            .ForMember(x => x.PhotoUrl, y => y.MapFrom(x => x.ProductPhotos.FirstOrDefault().Url));


        CreateMap<Product, ProductShopDto>()
            .ForMember(x => x.PhotoUrl, y => y.MapFrom(x => x.ProductPhotos.FirstOrDefault().Url));

        CreateMap<Category, CategoryBannerDto>();

        CreateMap<Product, ProductDetailDto>()
            .ForMember(x => x.PhotoUrl, z => z.MapFrom(x => x.ProductPhotos.Select(x => x.Url).ToList()));


        CreateMap<ProductCreateDto, Product>();

        CreateMap<Product, ProductDashboardDto>()
            .ForMember(x => x.PhotoUrl, y => y.MapFrom(x => x.ProductPhotos.FirstOrDefault().Url))
            .ForMember(z => z.CategoryName, a => a.MapFrom(x => x.Category.Name));
    }
}
