using DeveloperStore.Api.Application.DTOs;
using DeveloperStore.Api.Application.Exceptions;
using DeveloperStore.Api.Application.Mediator.Queries;
using DeveloperStore.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;
    
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProducts([FromQuery] int page = 1, 
        [FromQuery] int size = 10,
        [FromQuery] string orderBy = "")
    {
        try
        {
            var query = new GetAllProductsQuery(page, size, orderBy);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (CustomException.BusinessException ex)
        {
            // Se ocorrer um erro de negócio
            _logger.LogError(ex, "Business error occurred while fetching products.");
            return BadRequest(new ErrorResponse("An error occurred while processing your request.", 400));
        }
        catch (Exception ex)
        {
            // Se ocorrer qualquer outro erro inesperado
            _logger.LogError(ex, "Unexpected error occurred while fetching products.");
            return StatusCode(500, new ErrorResponse("An unexpected error occurred.", 500));
        }
    }
}