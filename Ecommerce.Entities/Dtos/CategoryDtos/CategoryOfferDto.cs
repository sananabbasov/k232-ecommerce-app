using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.CategoryDtos;

public class CategoryOfferDto
{
    public int Id { get; set; }
    public string BannerUrl { get; set; }
    public decimal DiscountPercent { get; set; }
}
