using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.BasketDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Controllers;

public class BasketController : Controller
{
    private readonly IProductService _productService;

    public BasketController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        List<BasketDto> baskets = new();
        string basket = Request.Cookies["cart"];
        if (basket == null)
        {
            List<BasketProductDto> basketProduct = new();
            return View(basketProduct);
        }
        baskets = JsonSerializer.Deserialize<List<BasketDto>>(basket);
        var result = _productService.GetProductsByIds(baskets);
        return View(result.Data);
    }

    public JsonResult GetBasket()
    {
        List<BasketDto> baskets = new();
        string basket = Request.Cookies["cart"];
        if (basket == null)
        {
            List<BasketProductDto> basketProduct = new();
            return Json(basketProduct);
        }
        baskets = JsonSerializer.Deserialize<List<BasketDto>>(basket);
        var result = _productService.GetProductsByIds(baskets);
        return Json(result.Data);
    }



}
