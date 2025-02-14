using System.Net;

namespace Exception.Exceptions
{
    public class NotFoundException(string message, string action)
        : CustomException(message)
    {
        private readonly string _message = message;
        public override string ErrorName => nameof(NotFoundException);
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErros()
        {
            return [_message];
        }

        public override string GetAction()
        {
            return action;
        }
    }
}
