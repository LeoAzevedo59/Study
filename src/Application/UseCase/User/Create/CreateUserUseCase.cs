using AutoMapper;
using Communication.Requests.Users;
using Communication.Utils;
using Domain.Repositories;
using Domain.Repositories.User;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.User.Create
{
    public class CreateUserUseCase(
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IMapper mapper,
        IUnityOfWork unityOfWork
    ) : ICreateUserUseCase
    {
        public async Task Execute(RequestCreateUserJson request)
        {
            Validate(request);

            Domain.Entities.User? entity =
                mapper.Map<Domain.Entities.User>(request);

            await userWriteOnlyRepository.Add(entity);
            await unityOfWork.Commit();
        }

        private void Validate(RequestCreateUserJson request)
        {
            CreateUserValidator validator = new();
            ValidationResult? result = validator.Validate(request);
            List<string> errorMessages =
                ErrorMessagesFilter.GetMessages(result);

            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(errorMessages,
                    "Valide os campos obrigatórios.");
            }
        }
    }
}
