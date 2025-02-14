using Communication.Responses.ResponseError;
using Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            CustomException customException =
                (CustomException)context.Exception;

            ResponseErrorJson responseError = new(
                customException.ErrorName,
                customException.GetErros(),
                customException.GetAction(),
                (HttpStatusCode)customException.StatusCode
            );

            context.HttpContext.Response.StatusCode =
                customException.StatusCode;
            context.Result = new ObjectResult(responseError);
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            int statusCode = StatusCodes.Status500InternalServerError;

            ResponseErrorJson responseError = new(
                nameof(Exception),
                "Erro desconhecido.",
                "Entre em contato com o suporte.",
                (HttpStatusCode)statusCode
            );

            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new ObjectResult(responseError);
        }
    }
}
