using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.BasketDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet("[action]")]
    public IActionResult Featured()
    {
        var result = _productService.GetHomeFeaturedProducts();
        return Ok(result);
    }


    [HttpGet("[action]")]
    public IActionResult Recent()
    {
        var result = _productService.GetHomeRecentProducts();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateDto productCreateDto)
    {
        var result = _productService.CreateProduct(productCreateDto);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult Dashboard()
    {
        var result = _productService.GetDashboardProducts();
        return Ok(result);
    }


    [HttpGet("[action]/{id}")]
    public IActionResult Update([FromRoute] int id)
    {
        var result = _productService.GetUpdatedProduct(id);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] ProductUpdateDto productUpdateDto)
    {
        var result = _productService.UpdateProduct(id, productUpdateDto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var result = _productService.GetProductById(id);
        return Ok(result);
    }


    [HttpGet("[action]")]
    public IActionResult Shop(int maxPrice, int categoryId, int currentPage, int sort, int minPrice = 0)
    {
        var result = _productService.GetShopPagination(maxPrice, categoryId, currentPage, sort, minPrice);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var result = _productService.RemoveProduct(id);
        return Ok(result);
    }

 
}
