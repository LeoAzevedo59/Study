using Application.UseCase.CommonValidator;
using Communication.Requests.Users;
using FluentValidation;

namespace Application.UseCase.User.Create
{
    public class CreateUserValidator : AbstractValidator<RequestCreateUserJson>
    {
        public CreateUserValidator()
        {
            RuleFor(prop => prop.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório.")
                .MaximumLength(320)
                .WithMessage("Nome deve conter no máximo 256 caracteres.")
                .SetValidator(new EmailValidator<RequestCreateUserJson>())
                .WithMessage("E-mail não é válido.");

            RuleFor(prop => prop.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .MaximumLength(32)
                .WithMessage("Nome deve conter no máximo 32 caracteres.");

            RuleFor(prop => prop.Password)
                .SetValidator(new PasswordValidator<RequestCreateUserJson>())
                .WithMessage("Senha é obrigatório.");
        }
    }
}
