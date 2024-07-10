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

    public IDataResult<List<ProductDashboardDto>> GetDashboardProducts()
    {
        try
        {
            var products = _productDal.GetDashboardProducts();
            var mapper = _mapper.Map<List<ProductDashboardDto>>(products);
            return new SuccessDataResult<List<ProductDashboardDto>>(mapper);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<List<ProductDashboardDto>>(e.Message);
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

    public IDataResult<ProductUpdateDto> GetUpdatedProduct(int id)
    {
        try
        {
            var product = _productDal.Get(x => x.Id == id);
            var res = _mapper.Map<ProductUpdateDto>(product);
            return new SuccessDataResult<ProductUpdateDto>(res);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<ProductUpdateDto>();
        }
    }

    public IResult UpdateProduct(int id, ProductUpdateDto productUpdateDtos)
    {
        try
        {
            var product = _productDal.Get(x => x.Id == id);
            product.Name = productUpdateDtos.Name;
            product.Price = productUpdateDtos.Price;
            product.DiscountPrice = productUpdateDtos.DiscountPrice;
            product.CategoryId = productUpdateDtos.CategoryId;
            product.Description = productUpdateDtos.Description;
            product.Information = productUpdateDtos.Information;
            product.Stock = productUpdateDtos.Stock;
            product.IsFeatured = productUpdateDtos.IsFeatured;
            product.UserId = productUpdateDtos.UserId;
            _productDal.Update(product);
            return new SuccessResult();
        }
        catch (System.Exception)
        {
            return new ErrorResult();
        }
    }
}
