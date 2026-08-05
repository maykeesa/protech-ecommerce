using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProtechEcommerce.Domain.Exceptions;

namespace ProtechEcommerce.API.ExceptionHandling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title, detail) = exception switch
        {
            EntityNotFoundException => (StatusCodes.Status404NotFound, "Recurso nao encontrado", exception.Message),
            ServiceException => (StatusCodes.Status400BadRequest, "Erro de regra de negocio", exception.Message),
            BadHttpRequestException badRequest => (badRequest.StatusCode, "Parametro invalido na requisicao", badRequest.Message),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor", "Ocorreu um erro inesperado. Tente novamente mais tarde.")
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(exception, "Erro nao tratado ao processar {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
        }
        else
        {
            logger.LogWarning(exception, "Erro esperado ao processar {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);
        }

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail
        }, cancellationToken);

        return true;
    }
}
