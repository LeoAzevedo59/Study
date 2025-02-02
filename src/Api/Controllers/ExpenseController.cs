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
        var useCase = new CreateExpenseUseCase();
        return Created(string.Empty, useCase.Execute(request));
    }
}