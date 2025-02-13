using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Domain.Entities;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Commands;

public class CreateProductCommand : IRequest<SuccessfullResponse<ProductDto>>
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public Rating Rating { get; set; }
}