using API.Catalog.Entities;

namespace API.Catalog.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoria);
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool?> DeleteProduct(string id);
    }
}
