using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;

namespace Ecommerce.Core.Business;

public class BusinessRule
{
    public static IResult CheckRules(params IResult[] logic){
        foreach (var method in logic)
        {
            if (!method.Success)
            {
                return new ErrorResult();
            }
        }
        return new SuccessResult();
    }
}
