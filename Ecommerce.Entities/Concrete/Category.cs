using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public string BannerUrl { get; set; }
    public bool IsBanner { get; set; }
    public bool IsFeatured { get; set; }
}
