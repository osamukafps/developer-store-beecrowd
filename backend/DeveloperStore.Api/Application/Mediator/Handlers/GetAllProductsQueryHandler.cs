using System.Text.Json;
using AutoMapper;
using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Application.Exceptions;
using DeveloperStore.Api.Application.Mediator.Queries;
using DeveloperStore.Api.Domain.Interfaces;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, SuccessfullResponse<IEnumerable<ProductDto>>>
{
    readonly IProductRepository _repository;
    readonly IMapper _mapper;
    readonly ILogger<GetAllProductsQueryHandler> _logger;

    public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<SuccessfullResponse<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var data = await _repository.GetAllAsync(request.Page, request.Size, request.OrderBy);
            var totalItems = await _repository.GetAllProductsCount();
            var totalPages = (int)Math.Ceiling((double)totalItems / request.Size);

            return new SuccessfullResponse<IEnumerable<ProductDto>>
            {
                Message = "Success",
                Data = _mapper.Map<IEnumerable<ProductDto>>(data.Item1),
                TotalItems = totalItems,
                CurrentPage = request.Page,
                TotalPages = totalPages
            };
        }
        catch (CustomException.RepositoryException err)
        {
            _logger.LogError(err, err.Message);
            throw new CustomException.BusinessException("An error occurred while retrieving the products.", err);
        }
        catch (Exception err)
        {
            _logger.LogError(err, "An unexpected error occurred.");
            throw new CustomException.BusinessException("An unexpected error occurred while processing your request.", err);
        }
    }
}