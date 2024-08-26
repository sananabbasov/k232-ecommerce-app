using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebUI.Models;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.WebUI.ViewModels;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.BasketDtos;
using System.Text.Json;

namespace Ecommerce.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    public HomeController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    public IActionResult Index()
    {
        var homeCats = _categoryService.GetHomeCategories();
        var homeFeatured = _productService.GetHomeFeaturedProducts();
        var homeRecent = _productService.GetHomeRecentProducts();
        var categoryOffers = _categoryService.GetCategoryOffers();
        var banner = _categoryService.GetBannerCatgories();
        HomeViewModel vm = new()
        {
            HomeCategories = homeCats,
            HomeFeaturedProducts = homeFeatured,
            HomeRecentProducts = homeRecent,
            CategoryOffers = categoryOffers,
            CategoryBanners = banner
        };
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public JsonResult AddToCart(int id)
    {
        List<BasketDto> baskets = new();
        CookieOptions option = new CookieOptions();
        option.Expires = DateTime.Now.AddMinutes(10);
        string basket = Request.Cookies["cart"];
        if (basket == null)
        {
            BasketDto basketDto = new()
            {
                ProductId = id,
                Quantity = 1
            };
            baskets.Add(basketDto);
            basket = JsonSerializer.Serialize(baskets);
        }
        else
        {
            baskets = JsonSerializer.Deserialize<List<BasketDto>>(basket);
            var findBasket = baskets.FirstOrDefault(x => x.ProductId == id);
            if (findBasket != null)
            {
                findBasket.Quantity += 1;
            }
            else
            {
                BasketDto basketDto = new()
                {
                    ProductId = id,
                    Quantity = 1
                };
                baskets.Add(basketDto);
            }

            basket = JsonSerializer.Serialize(baskets);
        }


        Response.Cookies.Append("cart", basket.ToString(), option);
        return Json("Ok");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
