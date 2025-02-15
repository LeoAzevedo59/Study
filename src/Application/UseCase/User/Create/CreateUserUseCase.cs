using AutoMapper;
using Communication.Requests.Users;
using Communication.Utils;
using Domain.Enums;
using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.User.Create
{
    public class CreateUserUseCase(
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUserReadOnlyRepository userReadOnlyRepository,
        IPasswordEncrypt passwordEncrypt,
        IMapper mapper,
        IUnityOfWork unityOfWork
    ) : ICreateUserUseCase
    {
        public async Task Execute(RequestCreateUserJson request)
        {
            await Validate(request);

            Domain.Entities.User? entity =
                mapper.Map<Domain.Entities.User>(request);

            entity.Role = RoleType.ADMIN;
            entity.Password = passwordEncrypt.Encrypt(request.Password);

            await userWriteOnlyRepository.Add(entity);
            await unityOfWork.Commit();
        }

        private async Task Validate(RequestCreateUserJson request)
        {
            CreateUserValidator validator = new();
            ValidationResult? result = validator.Validate(request);

            if (await userReadOnlyRepository.Exists(request.Email))
            {
                result.Errors.Add(new ValidationFailure
                {
                    ErrorMessage = "E-mail já cadastrado."
                });
            }

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
