using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.UserDtos;

namespace Ecommerce.Business.Abstract;

public interface IUserService
{
    UserDto GetUserInfo(string id);
}
