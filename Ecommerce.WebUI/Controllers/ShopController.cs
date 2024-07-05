using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enum;
using Ecommerce.Entities.Payloads;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Controllers;


public class ShopController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ShopController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }



    public IActionResult Detail(int id)
    {
        var detail = _productService.GetProductById(id);

        ShopDetailViewModel vm = new()
        {
            ProductDetail = detail
        };
        return View(vm);
    }


    public IActionResult Index(int maxPrice, int categoryId, int currentPage=1, int minPrice = 0, int pageSize=1,Sort sort= Sort.NONE)
    {
        var products = _productService.GetShopPagination(maxPrice,categoryId,currentPage,(int)sort,minPrice);

        ProductShopViewModel vm = new()
        {
            Pagination = products
        };

        return View(vm);
    }
}
