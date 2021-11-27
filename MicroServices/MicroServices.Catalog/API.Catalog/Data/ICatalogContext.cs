using API.Catalog.Entities;
using MongoDB.Driver;

namespace API.Catalog.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
