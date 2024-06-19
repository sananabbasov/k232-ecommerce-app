using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.CategoryDtos;

public class CategoryBannerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BannerUrl { get; set; }
}
