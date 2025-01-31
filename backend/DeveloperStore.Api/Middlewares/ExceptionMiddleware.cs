using System.Text.Json;
using DeveloperStore.Api.Application.Exceptions;
using DeveloperStore.Api.Responses;
using MongoDB.Bson.IO;

namespace DeveloperStore.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, 500, "An unexpected error occurred.");
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new ErrorResponse(message, statusCode);
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}