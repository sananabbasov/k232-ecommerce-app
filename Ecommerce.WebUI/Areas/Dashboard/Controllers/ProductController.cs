using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products  = _productService.GetDashboardProducts();
        return View(products.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductCreateDto productCreate, List<IFormFile> images)
    {  
        var result = _productService.CreateProduct(productCreate);
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
