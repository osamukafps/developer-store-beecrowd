namespace DeveloperStore.Api.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<(IEnumerable<T>, int)> GetAllAsync(int page, int totalItems, string orderBy);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}