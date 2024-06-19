using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Ecommerce.DataAccess.Concrete.MongoDriver;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.CategoryDtos;

namespace Ecommerce.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

    public void CreateCategory(Category category)
    {
        _categoryDal.Add(category);
    }

    public List<CategoryBannerDto> GetBannerCatgories()
    {
        var categories = _categoryDal.GetAll(x => x.IsBanner == true);
        var result = _mapper.Map<List<CategoryBannerDto>>(categories);
        return result;
    }

    public List<CategoryOfferDto> GetCategoryOffers()
    {
        var result = _categoryDal.SpecialOffers();
        var cats = _mapper.Map<List<CategoryOfferDto>>(result);
        return cats;
    }

    public List<CategoryHomeDto> GetHomeCategories()
    {
        var categories = _categoryDal.GetHomeCategories();
        var result = _mapper.Map<List<CategoryHomeDto>>(categories);
        return result;
    }
}
