using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.BasketDtos;
using Ecommerce.Entities.Dtos.CartDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Ecommerce.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{

    private readonly IProductService _productService;
    private readonly IDistributedCache _cache;

    public CartController(IProductService productService, IDistributedCache cache)
    {
        _productService = productService;
        _cache = cache;
    }

    [HttpGet("[action]/{userId}")]
    public async Task<IActionResult> GetProductsByIds(string userId)
    {
        string find = await _cache.GetStringAsync($"cart:123");
        if (find == null)
        {
            return Ok(new List<BasketDto>());
        }
        var items = JsonConvert.DeserializeObject<List<BasketDto>>(find);
        var cartProduct = _productService.GetProductsByIds(items);
        foreach (var cart in cartProduct.Data)
        {
            cart.Quantity = items.FirstOrDefault(z => z.ProductId == cart.Id).Quantity;
        }
        return Ok(cartProduct);
    }

    [HttpPost("[action]/{userId}")]
    public async Task<IActionResult> Add([FromBody] CartDto cart, string userId)
    {
        List<CartDto> resultcart = new();
        string basketKey = $"cart:{userId}";
        string find = await _cache.GetStringAsync(basketKey);
        if (find != null)
        {
            resultcart = JsonConvert.DeserializeObject<List<CartDto>>(find);
            var check = resultcart.FirstOrDefault(x => x.ProductId == cart.ProductId);
            if (check != null)
            {
                check.Quantity += cart.Quantity;
            }
            else
            {
                resultcart.Add(cart);
            }
        }
        else
        {
            resultcart.Add(cart);
        }
        var json = JsonConvert.SerializeObject(resultcart);
        await _cache.SetStringAsync(basketKey, json);
        return Ok();
    }
}
