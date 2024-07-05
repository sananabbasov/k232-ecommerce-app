using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.WebUI.ViewModels;

public class ProductShopViewModel
{
    public ProductPagination<ProductShopDto> Pagination { get; set; }
}
