using Communication.Requests.Users;

namespace Application.UseCase.User.Create
{
    public interface ICreateUserUseCase
    {
        Task Execute(RequestCreateUserJson request);
    }
}
