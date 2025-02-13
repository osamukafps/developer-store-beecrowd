using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Domain.Entities;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Queries;

public class GetProductByIdQuery : IRequest<SuccessfullResponse<ProductDto>>
{
    public int Id { get; set; }
}