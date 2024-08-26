using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.BasketDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.Business.Abstract;

public interface IProductService
{
    List<ProductHomeDto> GetHomeFeaturedProducts();
    List<ProductHomeDto> GetHomeRecentProducts();
    IDataResult<int> CreateProduct(ProductCreateDto productCreateDto);
    IDataResult<List<ProductDashboardDto>> GetDashboardProducts();
    IResult UpdateProduct(int id, ProductUpdateDto productUpdateDtos);
    IDataResult<ProductUpdateDto> GetUpdatedProduct(int id);
    ProductDetailDto GetProductById(int id);
    List<ProductShopDto> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0);
    ProductPagination<ProductShopDto> GetShopPagination(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0);
    IResult RemoveProduct(int productId);
    IDataResult<List<BasketProductDto>> GetProductsByIds(List<BasketDto> basketDto);
}
