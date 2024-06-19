using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class AppDbContext : IdentityDbContext<User>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=K232ShopAppDb; User Id=SA; Password=Ehmed123; TrustServerCertificate=True;");
        optionsBuilder.UseNpgsql("Server=testdb-do-user-14668122-0.c.db.ondigitalocean.com;Port=25060;Database=k232db;User Id=doadmin;Password=AVNS_rsUExsNCpNiGvqaWlY2;sslmode=Require;Trust Server Certificate=true;");

    }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public List<Review> Reviews { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");

        builder.Entity<Review>()
        .HasOne(x => x.User)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);

    }
}
