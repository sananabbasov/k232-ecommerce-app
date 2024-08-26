using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.OrderItemDtos;
using Ecommerce.Entities.Enum;

namespace Ecommerce.Entities.Dtos.OrderDtos;

public class CreateOrderDto
{
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public string DeliveryAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
