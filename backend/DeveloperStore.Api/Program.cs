using DeveloperStore.Api.Infra.Persistence.Context;
using DeveloperStore.Api.Infra.Persistence.Context.HealthCheck;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();