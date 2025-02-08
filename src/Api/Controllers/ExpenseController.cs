using Application.UseCase.Expense.Create;
using Communication.Requests.Expense;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpenseController(ICreateExpenseUseCase createExpenseUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RequestCreateExpenseJson request)
    {
        var response = await createExpenseUseCase.Execute(request);
        return Created(string.Empty, response);
    }
}