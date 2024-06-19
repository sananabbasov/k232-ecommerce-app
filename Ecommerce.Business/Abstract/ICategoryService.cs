using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.CategoryDtos;

namespace Ecommerce.Business.Abstract;

public interface ICategoryService
{
    void CreateCategory(Category category);
    List<CategoryHomeDto> GetHomeCategories();
    List<CategoryOfferDto> GetCategoryOffers();

    List<CategoryBannerDto> GetBannerCatgories();
}
