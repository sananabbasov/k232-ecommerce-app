using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.DataAccess;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.DataAccess.Abstract;

public interface ICategoryDal : IRepositoryBase<Category>
{
    List<Category> GetHomeCategories();
    List<Category> SpecialOffers();
}
