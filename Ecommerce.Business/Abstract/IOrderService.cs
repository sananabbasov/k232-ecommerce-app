using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.OrderDtos;

namespace Ecommerce.Business.Abstract;

public interface IOrderService
{
    IResult CreateOrder(CreateOrderDto createOrderDto);
    
}
