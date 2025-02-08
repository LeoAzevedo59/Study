using System.Net;
using Application.UseCase.Expense.Create;
using Communication.Requests.Expense;
using Communication.Responses.ResponseError;
using Exception.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpenseController(ICreateExpenseUseCase createExpenseUseCase) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestCreateExpenseJson request)
    {
        return Created(string.Empty, createExpenseUseCase.Execute(request));
    }
}