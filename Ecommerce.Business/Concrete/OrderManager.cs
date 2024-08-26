using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.OrderDtos;

namespace Ecommerce.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    private readonly IMapper _mapper;

    public OrderManager(IOrderDal orderDal, IMapper mapper)
    {
        _orderDal = orderDal;
        _mapper = mapper;
    }

    public IResult CreateOrder(CreateOrderDto createOrderDto)
    {
        try
        {
            var mapper = _mapper.Map<Order>(createOrderDto);
            _orderDal.Add(mapper);
            return new SuccessResult("Order created successfully.");
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }
}
