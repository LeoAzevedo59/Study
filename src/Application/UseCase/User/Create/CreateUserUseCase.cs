using AutoMapper;
using Communication.Requests.Users;
using Communication.Responses.User;
using Communication.Utils;
using Domain.Enums;
using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.User.Create
{
    internal class CreateUserUseCase(
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUserReadOnlyRepository userReadOnlyRepository,
        IPasswordEncrypt passwordEncrypt,
        IAccessTokenGenerator accessTokenGenerator,
        IMapper mapper,
        IUnityOfWork unityOfWork
    ) : ICreateUserUseCase
    {
        public async Task<ResponseUserAuthJson> Execute(
            RequestCreateUserJson request)
        {
            await Validate(request);

            Domain.Entities.User? entity =
                mapper.Map<Domain.Entities.User>(request);

            entity.Role = RoleType.ADMIN;
            entity.Password = passwordEncrypt.Encrypt(request.Password);

            await userWriteOnlyRepository.Add(entity);
            await unityOfWork.Commit();

            return new ResponseUserAuthJson
            {
                AccessToken = accessTokenGenerator.Generate(entity)
            };
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
