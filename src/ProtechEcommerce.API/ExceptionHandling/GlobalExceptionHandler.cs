using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.API.ExceptionHandling;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            EntityNotFoundException => (StatusCodes.Status404NotFound, "Recurso nao encontrado"),
            ServiceException => (StatusCodes.Status400BadRequest, "Erro de regra de negocio"),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor")
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }
}
