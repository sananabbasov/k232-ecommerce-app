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
    private readonly IProductPhotoService _productPhotoService;
    private readonly IWebHostEnvironment _env;

    public ProductController(ILogger<ProductController> logger, IProductService productService, IWebHostEnvironment env, IProductPhotoService productPhotoService)
    {
        _logger = logger;
        _productService = productService;
        _env = env;
        _productPhotoService = productPhotoService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetDashboardProducts();
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
        for (int i = 0; i < images.Count; i++)
        {
            var path = "/uploads/" + Guid.NewGuid().ToString() + Path.GetExtension(images[i].FileName);
            using (var stream = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                images[i].CopyTo(stream);
            }
            _productPhotoService.UploadImage(path, result.Data);
        }
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View();
    }


    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _productService.GetUpdatedProduct(id);
        if (product.Success)
        {
            return View(product.Data);
        }
        return NotFound();
    }


    [HttpPost]
    public IActionResult Update(int id, ProductUpdateDto productUpdateDto, List<IFormFile> images)
    {
        var result = _productService.UpdateProduct(id, productUpdateDto);
        if (images.Count > 0)
        {
            _productPhotoService.RemoveImages(id);
        }
        for (int i = 0; i < images.Count; i++)
        {
            var path = "/uploads/" + Guid.NewGuid().ToString() + Path.GetExtension(images[i].FileName);
            using (var stream = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                images[i].CopyTo(stream);
            }
            _productPhotoService.UploadImage(path, id);
        }
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View();
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        var result = _productService.RemoveProduct(id);
        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
