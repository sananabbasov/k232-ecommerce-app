using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebUI.Models;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.WebUI.ViewModels;
using Ecommerce.Business.Abstract;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
