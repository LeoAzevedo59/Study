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
        var customException = (CustomException)context.Exception;

        ResponseErrorJson responseError = new(
            name: customException.ErrorName,
            message: customException.GetErros(),
            action: customException.GetAction(),
            statusCode: (HttpStatusCode)customException.StatusCode
        );
        
        context.HttpContext.Response.StatusCode = customException.StatusCode;
        context.Result = new ObjectResult(responseError);
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