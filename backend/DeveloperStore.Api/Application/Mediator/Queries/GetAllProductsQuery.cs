using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Domain.Entities;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Queries;

public class GetAllProductsQuery : IRequest<SuccessfullResponse<IEnumerable<ProductDto>>>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string OrderBy { get; set; }

    public GetAllProductsQuery(int page = 1, int pageSize = 10, string orderBy = "")
    {
        Page = page;
        Size = pageSize;
        OrderBy = orderBy;
    }
}