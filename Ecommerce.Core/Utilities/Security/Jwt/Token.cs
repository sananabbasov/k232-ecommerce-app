using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;

namespace Ecommerce.Core.Utilities.Security.Jwt;

public static class Token
{
    public static string CreateToken(JwtUser user,string role)
    {
        var jwtHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes("djsfaskdfjlksjdflkjsdflkjasdlfaskldflkasdk");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                     new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                     new Claim(JwtRegisteredClaimNames.Email,user.Email),
                     new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim (ClaimTypes.Role, role),
                 }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = "Websuper.az",
            Audience = "Websuper.az"
        };

        var token = jwtHandler.CreateToken(tokenDescriptor);
        return jwtHandler.WriteToken(token);

    }
}
