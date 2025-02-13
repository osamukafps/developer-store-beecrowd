using AutoMapper;
using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Application.Exceptions;
using DeveloperStore.Api.Application.Mediator.Queries;
using DeveloperStore.Api.Domain.Interfaces;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, SuccessfullResponse<ProductDto>>
{
    readonly IProductRepository _productRepository;
    readonly IMapper _mapper;
    readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductByIdQueryHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<SuccessfullResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return new SuccessfullResponse<ProductDto>
                {
                    Message = "No Content",
                    Data = null
                };

            return new SuccessfullResponse<ProductDto>
            {
                Message = "Success",
                Data = _mapper.Map<ProductDto>(product)
            };
        }
        catch (CustomException.RepositoryException err)
        {
            _logger.LogError(err, err.Message);
            throw new CustomException.BusinessException("An error occurred while retrieving the product.", err);
        }
        catch (Exception err)
        {
            _logger.LogError(err, "An unexpected error occurred.");
            throw new CustomException.BusinessException("An unexpected error occurred while processing your request.", err);
        }
    }
}