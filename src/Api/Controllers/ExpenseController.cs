using Application.UseCase.Expense.Create;
using Application.UseCase.Expense.Delete;
using Application.useCase.Expense.Read;
using Application.useCase.Expense.ReadById;
using Application.UseCase.Expense.Update;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Communication.Responses.ResponseError;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    // [Authorize]
    public class ExpenseController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateExpenseJson),
            StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Crete(
            [FromServices] ICreateExpenseUseCase useCase,
            [FromBody] RequestCreateExpenseJson request)
        {
            ResponseCreateExpenseJson response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseReadExpensesJson),
            StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(
            [FromServices] IReadExpenseUseCase useCase)
        {
            List<ResponseReadExpensesJson> response = await useCase.Execute();

            if (response.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseReadExpensesJson),
            StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(
            [FromServices] IReadExpenseByIdUseCase useCase,
            [FromRoute] Guid id
        )
        {
            ResponseReadExpenseJson response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteExpenseUseCase useCase,
            [FromRoute] Guid id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateExpenseUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] RequestUpdateExpenseJson request
        )
        {
            await useCase.Execute(id, request);
            return NoContent();
        }
    }
}
