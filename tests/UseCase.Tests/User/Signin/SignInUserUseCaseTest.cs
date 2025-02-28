using Application.UseCase.User.SignIn;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories.User;
using CommonTestUtilities.Requests.User;
using CommonTestUtilities.Security.Cryptography;
using CommonTestUtilities.Security.Tokens;
using Communication.Requests.Users;
using Communication.Responses.User;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Exception.Exceptions;
using System.Net;

namespace UseCase.Test.User.Signin
{
    public class SignInUserUseCaseTest
    {
        private SignInUserUseCase CreateUseCase(Domain.Entities.User user,
            string? password = null)
        {
            IPasswordEncrypt passwordEncryptBuilder =
                new PasswordEncryptBuilder().Verify(password)
                    .Build();

            IAccessTokenGenerator
                accessTokenGeneratorBuilder = JwtTokenGeneratorBuilder.Build();

            IUserReadOnlyRepository userReadOnlyRepositoryBuilder =
                new UserReadOnlyRepositoryBuilder().GetByEmail(user).Build();


            return new SignInUserUseCase(passwordEncryptBuilder,
                userReadOnlyRepositoryBuilder,
                accessTokenGeneratorBuilder);
        }

        [Fact]
        public async Task UserSignIn_Success_ValidFields()
        {
            // ARRANGE
            RequestSigninUserJson
                request = RequestSignInUserJsonBuilder.Build();

            Domain.Entities.User user = UserBuild.Build();

            SignInUserUseCase useCase =
                CreateUseCase(user, request.Password);

            // ACT
            ResponseUserAuthJson result = await useCase.Execute(request);

            // ASSERT
            Assert.NotNull(result);
            Assert.NotEmpty(result.AccessToken);
        }


        [Fact]
        public async Task UserSignIn_Failure_EmailIsEmpty()
        {
            // ARRANGE
            RequestSigninUserJson
                request =
                    RequestSignInUserJsonBuilder.BuildWithEmail(string.Empty);

            Domain.Entities.User user = UserBuild.Build();

            SignInUserUseCase useCase =
                CreateUseCase(user, request.Password);

            // ACT
            Func<Task<ResponseUserAuthJson>> result = async () =>
                await useCase.Execute(request);

            // ASSERT
            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(result);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["E-mail é obrigatório."], exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Preencha um e-mail válido.", exception.GetAction());
        }

        [Fact]
        public async Task UserSignIn_Failure_PasswordIsEmpty()
        {
            // ARRANGE
            RequestSigninUserJson
                request =
                    RequestSignInUserJsonBuilder
                        .BuildWithPassword(string.Empty);

            Domain.Entities.User user = UserBuild.Build();

            SignInUserUseCase useCase =
                CreateUseCase(user, request.Password);

            // ACT
            Func<Task<ResponseUserAuthJson>> result = async () =>
                await useCase.Execute(request);

            // ASSERT
            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(result);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["Senha é obrigatório."], exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Preencha uma senha.", exception.GetAction());
        }

        [Fact]
        public async Task UserSignIn_Failure_UserNotFound()
        {
            // ARRANGE
            RequestSigninUserJson
                request = RequestSignInUserJsonBuilder.Build();

            Domain.Entities.User user = new("Usuario não existe",
                "email_nao_existe@exemple.com",
                "test123"
            );

            SignInUserUseCase useCase =
                CreateUseCase(user, request.Password);

            // ACT
            Func<Task<ResponseUserAuthJson>> result = async () =>
                await useCase.Execute(request);

            // ASSERT
            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(result);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["E-mail e/ou senha incorreto(s)."],
                exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Caso não lembre a senha redefina sua senha.",
                exception.GetAction());
        }

        [Fact]
        public async Task UserSignIn_Failure_PasswordNotMatch()
        {
            // ARRANGE
            RequestSigninUserJson
                request = RequestSignInUserJsonBuilder.Build();

            Domain.Entities.User user = UserBuild.Build();

            SignInUserUseCase useCase =
                CreateUseCase(user);

            // ACT
            Func<Task<ResponseUserAuthJson>> result = async () =>
                await useCase.Execute(request);

            // ASSERT
            ErrorOnValidationException exception =
                await Assert.ThrowsAsync<ErrorOnValidationException>(result);

            Assert.Equal("ErrorOnValidationException", exception.ErrorName);
            Assert.Equal(["E-mail e/ou senha incorreto(s)."],
                exception.GetErros());
            Assert.Equal((int)HttpStatusCode.BadRequest, exception.StatusCode);
            Assert.Equal("Caso não lembre a senha redefina sua senha.",
                exception.GetAction());
        }
    }
}
