using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class ProductPhoto : BaseEntity
{
    public string Url { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
