using DeveloperStore.Api.Domain.Entities;

namespace DeveloperStore.Api.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategory(string category);
    Task<IEnumerable<string>> GetCategories();
    Task<int> GetAllProductsCount();
}