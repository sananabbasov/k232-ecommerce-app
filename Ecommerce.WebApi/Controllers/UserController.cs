using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Ecommerce.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }


    [HttpGet("user")]
    [Authorize]
    public IActionResult GetUser()
    {
        var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
        var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
        var result = _userService.GetUserInfo(userId);
        return Ok(result);
    }
}
