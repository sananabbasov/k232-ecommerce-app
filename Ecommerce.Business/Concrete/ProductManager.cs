using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.ProductDtos;

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

    public List<ProductShopDto> GetShopProducts(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0)
    {
        var products = _productDal.GetShopProducts(maxPrice, categoryId,  currentPage,  sort,  minPrice);
        var res = _mapper.Map<List<ProductShopDto>>(products);
        return res;
    }
}
