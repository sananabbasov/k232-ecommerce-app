using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
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


    public IActionResult Index()
    {
        return View();
    }
}
