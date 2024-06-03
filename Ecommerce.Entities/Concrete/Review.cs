using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class Review : BaseEntity
{
    public float Point { get; set; }
    public string Message { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; }


    public Product Product { get; set; }
    public User User { get; set; }
}
