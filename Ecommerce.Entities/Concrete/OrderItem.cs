using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class OrderItem : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int OrderId { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Quantity { get; set; }
}
