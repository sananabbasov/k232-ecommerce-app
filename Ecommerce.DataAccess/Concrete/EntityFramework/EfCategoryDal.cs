using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.DataAccess.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>, ICategoryDal
{
    public List<Category> GetHomeCategories()
    {
        using var context = new AppDbContext();
        var result = context.Categories.Take(12).Include(x => x.Products).ToList();
        return result;
    }

    public List<Category> SpecialOffers()
    {
        using var context = new AppDbContext();
        var topCategoriesId = context.Products.OrderByDescending(x=>x.Price - x.DiscountPrice).GroupBy(x=>x.CategoryId).Select(x=>x.Key).Take(4).ToList();
        var result = context.Categories.Where(x=> topCategoriesId.Contains(x.Id)).Include(x => x.Products).ToList();
        return result;

    }
}
