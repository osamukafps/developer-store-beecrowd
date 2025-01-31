using DeveloperStore.Api.Application.Mappings;
using DeveloperStore.Api.Application.Mediator.Handlers;
using DeveloperStore.Api.Application.Services;
using DeveloperStore.Api.Application.Services.Interfaces;
using DeveloperStore.Api.Domain.Interfaces;
using DeveloperStore.Api.Infra.Persistence.Context;
using DeveloperStore.Api.Infra.Persistence.Context.HealthCheck;
using DeveloperStore.Api.Infra.Persistence.Repositories;
using DeveloperStore.Api.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Database configuration
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
AppDbContextHealthCheck.CheckConnection(builder.Configuration.GetConnectionString("Postgres"));

builder.Services.AddScoped<MongoDbContext>();
MongoDbContextHealthCheck.CheckConnection(builder.Configuration.GetConnectionString("MongoDb"), "developer_store_api_service");

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Services
builder.Services.AddScoped<IPaginationService, PaginationService>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();