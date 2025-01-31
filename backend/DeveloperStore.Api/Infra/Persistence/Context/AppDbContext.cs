using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Api.Infra.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .ToTable("products", "public")
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Product>()
            .OwnsOne(p => p.Rating, r =>
            {
                r.Property(p => p.Count).HasColumnName("RatingCount");
                r.Property(p => p.Rate).HasColumnName("RatingRate");
            });
    }
}