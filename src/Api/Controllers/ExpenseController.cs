using Application.UseCase.Expense.Create;
using Communication.Requests.Expense;
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
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error occured");
        }
    }
}