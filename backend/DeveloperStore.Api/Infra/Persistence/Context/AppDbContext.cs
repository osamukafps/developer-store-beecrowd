using DeveloperStore.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Api.Infra.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
    
    public DbSet<Product> Products { get; set; }
}