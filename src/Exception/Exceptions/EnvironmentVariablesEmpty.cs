using System.Net;

namespace Exception.Exceptions;

public class EnvironmentVariablesEmpty(string message, string action) : CustomException(message)
{
    public override string ErrorName => nameof(EnvironmentVariablesEmpty);
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    private readonly string _message = message;

    public override List<string> GetErros()
    {
     return [_message];
    }
    
    public override string GetAction()
    {
        return action;
    }
}