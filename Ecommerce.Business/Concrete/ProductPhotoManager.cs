using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.Business.Concrete;

public class ProductPhotoManager : IProductPhotoService
{
    private readonly IProductPhotoDal _productPhotoDal;

    public ProductPhotoManager(IProductPhotoDal productPhotoDal)
    {
        _productPhotoDal = productPhotoDal;
    }

    public IResult RemoveImages(int id)
    {
        try
        {
            var productPhotos = _productPhotoDal.GetAll(x=>x.ProductId == id);
            for (int i = 0; i < productPhotos.Count; i++)
            {
                _productPhotoDal.Delete(productPhotos[i]);
            }
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public IResult UploadImage(string photoUrl, int productId)
    {
        try
        {
            var photo = new ProductPhoto
            {
                Url = photoUrl,
                ProductId = productId
            };
            _productPhotoDal.Add(photo);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }
}
