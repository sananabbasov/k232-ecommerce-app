using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enum;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper)
    {
        _productDal = productDal;
        _mapper = mapper;
    }

    public IResult CreateProduct(ProductCreateDto productCreateDto)
    {
        try
        {
            var product = _mapper.Map<Product>(productCreateDto);
            _productDal.Add(product);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public List<ProductHomeDto> GetHomeFeaturedProducts()
    {
        var products = _productDal.GetFeatruedProducts();
        var res = _mapper.Map<List<ProductHomeDto>>(products);
        return res;
    }

    public List<ProductHomeDto> GetHomeRecentProducts()
    {
        var products = _productDal.GetRecentProducts();
        var res = _mapper.Map<List<ProductHomeDto>>(products);
        return res;
    }

    public ProductDetailDto GetProductById(int id)
    {
        var product = _productDal.GetProductById(id);
        var mapper = _mapper.Map<ProductDetailDto>(product);

        return mapper;
    }

    public ProductPagination<ProductShopDto> GetShopPagination(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0)
    {
        var result = _productDal.GetShopProducts(maxPrice, categoryId, currentPage, sort, minPrice);
        var products = _mapper.Map<List<ProductShopDto>>(result.Products);
        return new ProductPagination<ProductShopDto>(result.PageSize, result.CurrentPage, result.MaxPrice, result.MinPrice, result.CategoryId, result.Sort, products);
    }

    public List<ProductShopDto> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0)
    {
        var products = _productDal.GetShopProducts(maxPrice, categoryId, currentPage, sort, minPrice);
        var res = _mapper.Map<List<ProductShopDto>>(products);
        return res;
    }


}
