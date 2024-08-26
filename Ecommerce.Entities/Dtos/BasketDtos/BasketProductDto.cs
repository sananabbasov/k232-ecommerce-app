using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.BasketDtos;

public class BasketProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Quantity { get; set; }
}
