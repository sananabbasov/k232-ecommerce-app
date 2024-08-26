using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Dtos.UserDtos;

namespace Ecommerce.Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public UserDto GetUserInfo(string id)
    {
        var findUser = _userDal.Get(x=>x.Id == id);
        var user = _mapper.Map<UserDto>(findUser);

        return user;

    }
}
