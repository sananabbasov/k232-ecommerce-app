using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;

namespace Ecommerce.Business.Abstract;

public interface IProductPhotoService
{
    IResult UploadImage(string photoUrl, int productId);
    IResult RemoveImages(int id);
}
