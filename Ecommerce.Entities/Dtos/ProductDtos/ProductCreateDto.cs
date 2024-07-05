using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductCreateDto
{
    [Required]
    [Length(4,50, ErrorMessage ="Ad minimum 4 maksimum 50 simvol olmalidir")]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public string Information { get; set; }
    public int Stock { get; set; }
    public bool IsFeatured { get; set; }
    public int CategoryId { get; set; }
    public string UserId { get; set; }
}
