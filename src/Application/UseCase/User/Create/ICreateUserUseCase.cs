using Communication.Requests.Users;
using Communication.Responses.User;

namespace Application.UseCase.User.Create
{
    public interface ICreateUserUseCase
    {
        Task<ResponseCreateUserJson> Execute(RequestCreateUserJson request);
    }
}
