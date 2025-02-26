using Application.UseCase.User.Create;
using Communication.Requests.Users;
using Communication.Responses.ResponseError;
using Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserAuthJson),
            StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateUserUseCase useCase,
            [FromBody] RequestCreateUserJson request
        )
        {
            ResponseUserAuthJson response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
