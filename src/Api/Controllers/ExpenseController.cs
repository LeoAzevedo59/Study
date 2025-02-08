using Application.UseCase.Expense.Create;
using Application.useCase.Expense.Read;
using Application.useCase.Expense.ReadById;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Communication.Responses.ResponseError;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpenseController() : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] ICreateExpenseUseCase createExpenseUseCase,
        [FromBody] RequestCreateExpenseJson request)
    {
        var response = await createExpenseUseCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseReadExpensesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get([FromServices] IReadExpenseUseCase readExpenseUseCase)
    {
        var response = await readExpenseUseCase.Execute();
        
        if(response.Count == 0)
            return NoContent();
        
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseReadExpensesJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IReadExpenseByIdUseCase readExpenseByIdUseCase,
        [FromRoute] Guid id
        )
    {
        var response = await readExpenseByIdUseCase.Execute(id);
        return Ok(response);
    }
}