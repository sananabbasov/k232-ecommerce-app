using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Enum;

namespace Ecommerce.Entities.Concrete;

public class Order : BaseEntity
{
    public string UserId { get; set; }
    public User User { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public string DeliveryAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
