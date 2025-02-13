using System.Linq.Expressions;
using DeveloperStore.Api.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Api.Application.Services;

public class PaginationService : IPaginationService
{
    public async Task<(IEnumerable<T>, int)> ApplyPaginationAndSorting<T>(IQueryable<T> query, int page, int pageSize, string orderBy)
    {
        if (!string.IsNullOrEmpty(orderBy))
        {
            var orderByParts = orderBy.Split(',');
            foreach (var part in orderByParts)
            {
                var parts = part.Trim().Split(' ');
                var property = parts[0];
                var direction = parts.Length > 1 && parts[1].ToLower() == "desc";

                var parameter = Expression.Parameter(typeof(T), "x");
                var propertyExpression = Expression.Property(parameter, property);
                var lambda = Expression.Lambda(propertyExpression, parameter);

                var methodName = direction ? "OrderByDescending" : "OrderBy";
                var method = typeof(Queryable).GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2);

                var genericMethod = method.MakeGenericMethod(typeof(T), propertyExpression.Type);
                query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, lambda });
            }
        }

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalItems);
    }
}