using Application.UseCase.User.Create;
using AutoMapper;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.User;
using CommonTestUtilities.Requests.User;
using CommonTestUtilities.Security.Cryptography;
using CommonTestUtilities.Security.Tokens;
using Communication.Requests.Users;
using Communication.Responses.User;
using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Exception.Exceptions;
using System.Net;

namespace UseCase.Test.User.Create
{
    public class CreateUserUseCaseTest
    {
        private CreateUserUseCase CreateUseCase(string? email = null)
        {
            IMapper? mapperBuilder = MapperBuilder.Build();

            IUnityOfWork unitOfWorkBuilder = UnitOfWorkBuilder.Build();

            IUserWriteOnlyRepository userWriteOnlyRepositoryBuilder =
                UserWriteOnlyRepositoryBuilder.Build();

            UserReadOnlyRepositoryBuilder userReadOnlyRepositoryBuilder = new();

            IPasswordEncrypt passwordEncryptBuilder =
                PasswordEncryptBuilder.Build();

            if (!string.IsNullOrEmpty(email))
            {
                userReadOnlyRepositoryBuilder.ExistUserWithEmail(email);
            }

            IAccessTokenGenerator
                accessTokenGeneratorBuilder = JwtTokenGeneratorBuilder.Build();

            return new CreateUserUseCase(userWriteOnlyRepositoryBuilder,
                userReadOnlyRepositoryBuilder.Build(),
                passwordEncryptBuilder,
                accessTokenGeneratorBuilder,
                mapperBuilder,
                unitOfWorkBuilder);
        }

        [Fact]
        public async Task UserCreate_Success_ValidFields()
        {
            RequestCreateUserJson
                request = RequestCreateUserJsonBuilder.Build();
            CreateUserUseCase useCase = CreateUseCase();

            ResponseUserAuthJson result = await useCase.Execute(request);

            Assert.NotNull(result);
            Assert.NotEmpty(result.AccessToken);
        }

        [Fact]
        public async Task UserCreate_EmailAlreadyExists_Error()
        {
            RequestCreateUserJson
                request = RequestCreateUserJsonBuilder.Build();

            CreateUserUseCase useCase = CreateUseCase(request.Email);

            Func<Task<ResponseUserAuthJson>> act = async () =>
                await useCase.Execute(request);

            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["E-mail já cadastrado."], exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Valide os campos obrigatórios.",
                exception.GetAction());
        }

        [Fact]
        public async Task UserCreate_NameEmpty_Error()
        {
            RequestCreateUserJson
                request = RequestCreateUserJsonBuilder.Build();
            request.Name = string.Empty;

            CreateUserUseCase useCase = CreateUseCase();

            Func<Task<ResponseUserAuthJson>> act = async () =>
                await useCase.Execute(request);

            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["Nome é obrigatório."], exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Valide os campos obrigatórios.",
                exception.GetAction());
        }
    }
}
