using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet("[action]")]
    public IActionResult GetBanner()
    {
        var result = _categoryService.GetBannerCatgories();
        return Ok(result);
    }


    [HttpGet("[action]")]
    public IActionResult GetOffers()
    {
        var result = _categoryService.GetCategoryOffers();
        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult GetHome()
    {
        var result = _categoryService.GetHomeCategories();
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] Category category)
    {
        _categoryService.CreateCategory(category);
        return Ok(HttpStatusCode.Created);
    }
}
