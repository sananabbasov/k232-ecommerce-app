using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductDashboardDto
{
    public int Id { get; set; }
    public string PhotoUrl { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public decimal DiscountPrice { get; set; }
}
