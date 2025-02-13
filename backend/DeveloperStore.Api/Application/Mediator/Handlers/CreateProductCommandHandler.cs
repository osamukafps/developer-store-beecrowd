using System.Text.Json;
using AutoMapper;
using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Application.Exceptions;
using DeveloperStore.Api.Application.Mediator.Commands;
using DeveloperStore.Api.Domain.Entities;
using DeveloperStore.Api.Domain.Interfaces;
using DeveloperStore.Api.Responses;
using MediatR;

namespace DeveloperStore.Api.Application.Mediator.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, SuccessfullResponse<ProductDto>>
{
    readonly IProductRepository _productRepository;
    readonly IMapper _mapper;
    readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<SuccessfullResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(product);
            _mapper.Map<ProductDto>(product);

            return new SuccessfullResponse<ProductDto>()
            {
                Message = "Success",
                Data = _mapper.Map<ProductDto>(product)
            };
        }catch (CustomException.RepositoryException err)
        {
            _logger.LogError(err, err.Message);
            throw new CustomException.BusinessException("An error occurred while inserting products.", err);
        }
        catch (Exception err)
        {
            _logger.LogError(err, "An unexpected error occurred.");
            throw new CustomException.BusinessException("An unexpected error occurred while processing your request.", err);
        }
    }
}