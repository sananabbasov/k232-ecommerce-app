using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class User : Microsoft.AspNetCore.Identity.IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
