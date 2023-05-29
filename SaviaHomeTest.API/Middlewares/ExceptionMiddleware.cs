using SaviaHomeTest.Application.Responses;
using SaviaHomeTest.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace SaviaHomeTest.API.Middlewares;

/// <summary>
/// Middleware to handle unhandled exceptions
/// </summary>
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
        catch (InputValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var customError = new ErrorResponse<string>("Invalid data", ex.Message, ex.ValidationErrors);

            var result = JsonSerializer.Serialize(customError);

            await context.Response.WriteAsync(result);
        }
        catch (InconsistenceInReadDatabaseException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var customError = new ErrorResponse<string>("Inconsistence in READ database", ex.Message);

            var result = JsonSerializer.Serialize(customError);

            await context.Response.WriteAsync(result);
        }
        catch (InconsistenceInWriteDatabaseException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var customError = new ErrorResponse<string>("Inconsistence in WRITE database", ex.Message);

            var result = JsonSerializer.Serialize(customError);

            await context.Response.WriteAsync(result);
        }
        catch (KeyNotFoundException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var customError = new ErrorResponse<string>("Key not found", ex.Message);

            var result = JsonSerializer.Serialize(customError);

            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var customError = new ErrorResponse<string>("Contact the admin", ex.Message);

            var result = JsonSerializer.Serialize(customError);

            await context.Response.WriteAsync(result);
        }
    }
}
