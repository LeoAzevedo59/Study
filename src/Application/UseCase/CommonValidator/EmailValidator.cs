using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Application.UseCase.CommonValidator
{
    public class EmailValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "Email";

        public override bool IsValid(ValidationContext<T> context, string email)
        {
            string regexEmail =
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!string.IsNullOrEmpty(email) &&
                !Regex.IsMatch(email, regexEmail))
            {
                return false;
            }

            string[] emailArray = email.Split('@');
            int localPart = 0;
            int domain = 1;


            if (emailArray[localPart].Length > 64)
            {
                return false;
            }

            if (emailArray[domain].Length > 256)
            {
                return false;
            }

            if (emailArray[domain].StartsWith("."))
            {
                return false;
            }

            if (emailArray[domain].Contains("-") ||
                emailArray[domain].Contains("#") ||
                emailArray[domain].Contains("*"))
            {
                return false;
            }

            string consecutiveDotsPattern = @"\.\.";

            if (Regex.IsMatch(email, consecutiveDotsPattern))
            {
                return false;
            }

            if (emailArray[localPart].EndsWith("."))
            {
                return false;
            }

            if (emailArray[localPart].StartsWith("."))
            {
                return false;
            }

            return true;
        }
    }
}
