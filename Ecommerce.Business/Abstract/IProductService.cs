using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.Business.Abstract;

public interface IProductService
{
    List<ProductHomeDto> GetHomeFeaturedProducts();
    List<ProductHomeDto> GetHomeRecentProducts();

    ProductDetailDto GetProductById(int id);

    List<ProductShopDto> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0);

}
