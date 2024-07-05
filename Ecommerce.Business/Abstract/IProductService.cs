using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.Business.Abstract;

public interface IProductService
{
    List<ProductHomeDto> GetHomeFeaturedProducts();
    List<ProductHomeDto> GetHomeRecentProducts();
    IResult CreateProduct(ProductCreateDto productCreateDto);
    ProductDetailDto GetProductById(int id);

    List<ProductShopDto> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0);
    ProductPagination<ProductShopDto> GetShopPagination(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0);

}
