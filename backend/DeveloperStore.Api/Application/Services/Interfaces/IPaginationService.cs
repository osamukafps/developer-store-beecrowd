namespace DeveloperStore.Api.Application.Services.Interfaces;

public interface IPaginationService
{
    Task<(IEnumerable<T>, int)> ApplyPaginationAndSorting<T>(IQueryable<T> query, int page, int pageSize, string orderBy);
}