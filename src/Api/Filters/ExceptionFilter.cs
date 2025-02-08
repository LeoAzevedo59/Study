using System.Net;
using Communication.Responses.ResponseError;
using Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CustomException)
        {
            HandleProjectException(context);
            ;
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException errorOnValidationException)
        {
            int statusCode = StatusCodes.Status400BadRequest;

            ResponseErrorJson responseError = new(
                name: nameof(ErrorOnValidationException),
                message: errorOnValidationException.ErrorMessages,
                action: "Valide os campos obrigatórios.",
                statusCode: (HttpStatusCode)statusCode
            );
            
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new BadRequestObjectResult(responseError);
        }
        else if (context.Exception is EnvironmentVariablesEmpty environmentVariablesEmpty)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            
            ResponseErrorJson responseError = new(
                name: nameof(ErrorOnValidationException),
                message: environmentVariablesEmpty.ErrorMessage,
                action: "Entre em contato com o suporte.",
                statusCode: (HttpStatusCode)statusCode
            );
            
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new BadRequestObjectResult(responseError);
        }
        else
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            
            ResponseErrorJson responseError = new(
                name: nameof(CustomException),
                message: context.Exception.Message,
                action: "Entre em contato com o suporte.",
                statusCode: (HttpStatusCode)statusCode
            );
        }
    }
    
    private void ThrowUnkowError(ExceptionContext context)
    {
        int statusCode = StatusCodes.Status500InternalServerError;
        
        ResponseErrorJson responseError = new(
            name: nameof(Exception),
            message: "Erro desconhecido.",
            action: "Entre em contato com o suporte.",
            statusCode: (HttpStatusCode)statusCode
        );
        
        context.HttpContext.Response.StatusCode = statusCode;
        context.Result = new ObjectResult(responseError);
    }
}