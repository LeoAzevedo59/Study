using System.Net;

namespace Exception.Exceptions
{
    public class ErrorOnValidationException(
        List<string> errorMessages,
        string action) : CustomException(string.Empty)
    {
        public override string ErrorName => nameof(ErrorOnValidationException);
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErros()
        {
            return errorMessages;
        }

        public override string GetAction()
        {
            return action;
        }
    }
}
