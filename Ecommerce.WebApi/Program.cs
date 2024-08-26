using Ecommerce.Business.DependencyResolvers;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Ecommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var corsRuls = "_corsRules";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddBusinessRegistration();



builder.Services.AddCors(o =>
{
    o.AddPolicy(corsRuls,
         p =>
         {
             p.AllowAnyHeader();
             p.AllowAnyMethod();
             p.AllowAnyOrigin();
         }
        );
});

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();;


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes("djsfaskdfjlksjdflkjsdflkjasdlfaskldflkasdk");
    var issuer = "Websuper.az";
    var audience = "Websuper.az";

    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        RequireExpirationTime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = audience,
        ValidIssuer = issuer,
    };
});

builder.Services.AddStackExchangeRedisCache(option =>
        {
            option.Configuration = "localhost";
            option.InstanceName = "cart";
        });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseCors(corsRuls);
app.MapControllers();
app.Run();
