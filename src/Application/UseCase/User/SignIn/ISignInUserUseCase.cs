using Communication.Requests.Users;
using Communication.Responses.User;

namespace Application.UseCase.User.SignIn
{
    public interface ISignInUserUseCase
    {
        Task<ResponseUserAuthJson> Execute(RequestSigninUserJson request);
    }
}
