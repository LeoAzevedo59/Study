using Communication.Requests.Users;
using Communication.Responses.User;

namespace Application.UseCase.User.Signin
{
    public interface ISigninUserUseCase
    {
        Task<ResponseUserAuthJson> Execute(RequestSigninUserJson request);
    }
}
