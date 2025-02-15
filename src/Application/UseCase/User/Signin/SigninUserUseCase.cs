using Communication.Requests.Users;
using Communication.Responses.User;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Exception.Exceptions;

namespace Application.UseCase.User.Signin
{
    public class SigninUserUseCase(
        IPasswordEncrypt passwordEncrypt,
        IUserReadOnlyRepository userReadOnlyRepository,
        IAccessTokenGenerator accessTokenGenerator)
        : ISigninUserUseCase
    {
        public async Task<ResponseUserAuthJson> Execute(
            RequestSigninUserJson request)
        {
            Domain.Entities.User? user =
                await userReadOnlyRepository.GetByEmail(request.Email);

            Validate(request, user);

            return new ResponseUserAuthJson
            {
                AccessToken = accessTokenGenerator.Generate(user!)
            };
        }

        private void Validate(RequestSigninUserJson request,
            Domain.Entities.User? user)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new ErrorOnValidationException(
                    ["E-mail é obrigatório."], "Preencha um e-mail válido.");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new ErrorOnValidationException(
                    ["Senha é obrigatório."], "Preencha uma senha.");
            }

            if (user is null)
            {
                throw new ErrorOnValidationException(
                    ["E-mail e/ou senha incorreto(s)."],
                    "Caso não lembre a senha redefina sua senha.");
            }

            if (!passwordEncrypt.Verify(request.Password, user.Password))
            {
                throw new ErrorOnValidationException(
                    ["E-mail e/ou senha incorreto(s)."],
                    "Caso não lembre a senha redefina sua senha.");
            }
        }
    }
}
