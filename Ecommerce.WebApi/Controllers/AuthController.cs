using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Payloads;
using Ecommerce.Core.Utilities.Security.Jwt;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return NotFound();
        }
        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false,false);

        if (result.Succeeded)
        {
            JwtUser loggedUser = new()
            {
                Id = user.Id,
                Email = user.Email
            };
            var token = Token.CreateToken(loggedUser,"ADMIN");
            ApiPayload apiPayload = new(true,token);
            return Ok(apiPayload);
        }
        return NotFound("Email ve ya sifre yanlisdir");
    }



    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {

        var findUser = await _userManager.FindByEmailAsync(registerDto.Email);
        if (findUser != null)
        {
            return BadRequest("Bele bir istifadeci artiq movcuddur");
        }
        User user = new()
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName
        };


        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();

    }
}
