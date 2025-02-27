using FluentValidation;
using FluentValidation.Validators;

namespace Application.UseCase.CommonValidator
{
    internal class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";

        public override bool IsValid(ValidationContext<T> context,
            string password)
        {
            return !string.IsNullOrEmpty(password);
        }
    }
}
