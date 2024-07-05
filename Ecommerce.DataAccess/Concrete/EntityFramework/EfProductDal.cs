using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Core.DataAccess.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Enum;
using Ecommerce.Entities.Payloads;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
{
    public List<Product> GetFeatruedProducts()
    {
        using var context = new AppDbContext();
        var products = context.Products.Include(x=>x.ProductPhotos).Take(8).ToList();
        return products;
    }

    public Product GetProductById(int id)
    {
        using var context = new AppDbContext();
        var product = context.Products.Include(x=>x.ProductPhotos).FirstOrDefault(x=>x.Id == id);
        return product;
    }

    public List<Product> GetRecentProducts()
    {
        using var context = new AppDbContext();
        var products = context.Products.Include(x=>x.ProductPhotos).OrderByDescending(x=>x.Id).Take(8).ToList();
        return products;
    }

    public ProductPagination<Product> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort,int minPrice=0)
    {

        using var context = new AppDbContext();
        currentPage = currentPage == 0 ? 1 : currentPage;
        int skip = (currentPage - 1) * 9;
        var pageSize = context.Products.Count() / 9;
        var products = context.Products.Skip(skip).Take(9).Include(x=>x.ProductPhotos).OrderByDescending(x=>x.Id).ToList();
        return new ProductPagination<Product>(pageSize,currentPage,maxPrice,minPrice,categoryId,Sort.DESC,products);
    }
}
