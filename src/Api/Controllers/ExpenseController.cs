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
        var useCase = new CreateExpenseUseCase();
        
        return Ok(useCase.Execute(request));
    }
}