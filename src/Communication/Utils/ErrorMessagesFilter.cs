using FluentValidation.Results;

namespace Communication.Utils
{
    public static class ErrorMessagesFilter
    {
        public static List<string> GetMessages(
            ValidationResult validationResult)
        {
            List<string> errorMessages = validationResult
                .Errors
                .Select(error => error.ErrorMessage)
                .ToList();

            return errorMessages;
        }
    }
}
