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
                .WithMessage("E-mail é obrigatório")
                .EmailAddress()
                .WithMessage("E-mail não é válido.")
                .MaximumLength(256)
                .WithMessage("Nome deve conter no máximo 256 caracteres");

            RuleFor(prop => prop.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório")
                .MaximumLength(32)
                .WithMessage("Nome deve conter no máximo 32 caracteres");

            RuleFor(prop => prop.Password)
                .NotEmpty()
                .WithMessage("Password é obrigatório");
        }
    }
}
