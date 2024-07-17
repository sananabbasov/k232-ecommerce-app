using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Business.AutoMapper;
using Ecommerce.Business.Concrete;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Ecommerce.DataAccess.DataSeeder;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Business.DependencyResolvers;

public static class ServiceRegistration
{
    public static void AddBusinessRegistration(this IServiceCollection services)
    {


        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IProductService, ProductManager>();

        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICategoryService, CategoryManager>();

        services.AddScoped<IProductPhotoDal, EfProductPhotoDal>();
        services.AddScoped<IProductPhotoService, ProductPhotoManager>();

        DummyData.Create();



        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);


    }
}
