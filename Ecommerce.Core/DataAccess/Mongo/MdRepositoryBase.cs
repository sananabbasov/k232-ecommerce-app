using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ecommerce.Core.DataAccess.Mongo;


public class MdRepositoryBase<TDocument> : IRepositoryBase<TDocument>
{
    private IMongoCollection<TDocument> _collection;
    private protected string GetCollectionName(Type documentType)
    {
        return ((TableAttribute)documentType.GetCustomAttributes(
                typeof(TableAttribute),
                true)
            .FirstOrDefault())?.Name;
    }

    public void Add(TDocument entity)
    {
        var database = new MongoClient("mongodb://localhost:27917").GetDatabase("K232Ecommerce");
        _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        _collection.InsertOne(entity);
    }

    public void Delete(TDocument entity)
    {
        throw new NotImplementedException();
    }

    public TDocument Get(Expression<Func<TDocument, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<TDocument> GetAll(Expression<Func<TDocument, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(TDocument entity)
    {
        throw new NotImplementedException();
    }
}
