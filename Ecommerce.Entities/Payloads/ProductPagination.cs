using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enum;

namespace Ecommerce.Entities.Payloads;

public class ProductPagination<T>
{
    public ProductPagination(int pageSize, int currentPage, int maxPrice, int minPrice, int categoryId, Sort sort, List<T> products)
    {
        PageSize = pageSize;
        CurrentPage = currentPage;
        MaxPrice = maxPrice;
        MinPrice = minPrice;
        CategoryId = categoryId;
        Sort = sort;
        Products = products;
    }

    public int PageSize { get; }
    public int CurrentPage { get; }
    public int MaxPrice { get; }
    public int MinPrice { get; }
    public int CategoryId { get; }
    public Sort Sort { get; }
    public List<T> Products { get; }


}
