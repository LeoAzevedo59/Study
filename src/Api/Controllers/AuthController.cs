using Application.UseCase.User.SignIn;
using Communication.Requests.Users;
using Communication.Responses.ResponseError;
using Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(ResponseUserAuthJson),
            StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson),
            StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Signin(
            [FromServices] ISignInUserUseCase useCase,
            [FromBody] RequestSigninUserJson request
        )
        {
            ResponseUserAuthJson response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
