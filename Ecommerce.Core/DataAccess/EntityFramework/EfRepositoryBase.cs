using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.DataAccess.EntityFramework;

public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
    where TContext : DbContext, new()
    where TEntity : class
{



    public void Add(TEntity entity)
    {
        using var context = new TContext();
        var modelState = context.Entry(entity);
        modelState.State = EntityState.Added;
        context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var context = new TContext();
        var modelState = context.Entry(entity);
        modelState.State = EntityState.Deleted;
        context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        var result = context.Set<TEntity>().FirstOrDefault(filter);
        return result;
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        return filter == null
                  ? context.Set<TEntity>().ToList()
                  : context.Set<TEntity>().Where(filter).ToList();
    }

    public void Update(TEntity entity)
    {
        using var context = new TContext();
        var modelState = context.Entry(entity);
        modelState.State = EntityState.Modified;
        context.SaveChanges();
    }
}
