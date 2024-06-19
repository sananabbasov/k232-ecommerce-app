using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductDetailDto
{
    public int Id { get; set; }
    public List<string> PhotoUrl { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Information { get; set; }
    public decimal DiscountPrice { get; set; }

}
