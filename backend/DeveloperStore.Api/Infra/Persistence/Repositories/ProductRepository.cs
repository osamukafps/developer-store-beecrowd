using System.Linq.Expressions;
using DeveloperStore.Api.Application.Services.Interfaces;
using DeveloperStore.Api.Domain.Entities;
using DeveloperStore.Api.Domain.Interfaces;
using DeveloperStore.Api.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Api.Infra.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IPaginationService _paginationService;
    
    public ProductRepository(AppDbContext context, IPaginationService service)
    {
        _context = context;
        _paginationService = service;
    }


    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Rating)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<(IEnumerable<Product>, int)> GetAllAsync(int page, int pageSize, string orderBy)
    {
        var query = _context.Products.AsQueryable();
        var (items, totalItems) = await _paginationService.ApplyPaginationAndSorting(query, page, pageSize, orderBy);
        
        return (items, totalItems);
    }

    public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _context.Products
            .Include(p => p.Rating)
            .Where(predicate)
            .ToListAsync();
    }

    public async Task AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
    {
        return await _context.Products
            .Include(p => p.Rating)
            .Where(p => p.Category == category)
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetCategories()
    {
        return await _context.Products
            .Select(p => p.Category)
            .Distinct()
            .ToListAsync();
    }

    public async Task<int> GetAllProductsCount()
    {
        return await _context.Products.CountAsync();
    }
}