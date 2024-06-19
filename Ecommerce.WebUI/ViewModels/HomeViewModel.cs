using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.WebUI.ViewModels;

public class HomeViewModel
{
    public List<CategoryHomeDto> HomeCategories { get; set; }
    public List<ProductHomeDto> HomeFeaturedProducts { get; set; }
    public List<ProductHomeDto> HomeRecentProducts { get; set; }
    public List<CategoryOfferDto>  CategoryOffers { get; set; }
    public List<CategoryBannerDto> CategoryBanners { get; set; }
}
