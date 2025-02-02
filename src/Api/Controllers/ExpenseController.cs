using System.Net;
using Application.UseCase.Expense.Create;
using Communication.Requests.Expense;
using Communication.Responses.ResponseError;
using Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpenseController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestCreateExpenseJson request)
    {
        try
        {
            var useCase = new CreateExpenseUseCase();
            return Ok(useCase.Execute(request));
        }
        catch (ErrorOnValidationException e)
        {
            ResponseErrorJson responseError = new(
                name: nameof(ArgumentException),
                message: e.ErrorMessages,
                action: "Valide o(s) campo(s).",
                statusCode: HttpStatusCode.BadRequest
            );
            
            return BadRequest(responseError);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);

            ResponseErrorJson responseError = new(
                name: nameof(Exception),
                message: "Unknown error occured",
                action: "Contate o suporte.",
                statusCode: HttpStatusCode.InternalServerError
            );
            
            return StatusCode(StatusCodes.Status500InternalServerError, responseError);
        }
    }
}