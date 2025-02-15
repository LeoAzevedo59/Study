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
        [ProducesResponseType(typeof(ResponseCreateUserJson),
            StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] ICreateUserUseCase useCase,
            [FromBody] RequestCreateUserJson request
        )
        {
            ResponseCreateUserJson response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
