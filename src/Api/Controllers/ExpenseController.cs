using System.Net;
using Application.UseCase.Expense.Create;
using Communication.Requests.Expense;
using Communication.Responses.ResponseError;
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
        catch (ArgumentException e)
        {
            ResponseErrorJson responseError = new()
            {
                Name = nameof(ArgumentException),
                Message = e.Message,
                Action = "Valide o(s) campo(s).",
                StatusCode = HttpStatusCode.BadRequest
            };
            
            return BadRequest(responseError);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            ResponseErrorJson responseError = new()
            {
                Name = nameof(Exception),
                Message = "Unknown error occured",
                Action = "Contate o suporte.",
                StatusCode = HttpStatusCode.InternalServerError
            };
            
            return StatusCode(StatusCodes.Status500InternalServerError, responseError);
        }
    }
}