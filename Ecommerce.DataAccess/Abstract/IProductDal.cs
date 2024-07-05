using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.DataAccess;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.DataAccess.Abstract;

public interface IProductDal : IRepositoryBase<Product>
{
    List<Product> GetFeatruedProducts();
    List<Product> GetRecentProducts();
    Product GetProductById(int id);
    ProductPagination<Product> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort,int minPrice=0);
}
