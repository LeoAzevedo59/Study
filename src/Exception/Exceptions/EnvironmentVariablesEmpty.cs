namespace Exception.Exceptions;

public class EnvironmentVariablesEmpty(string errorMessage) : CustomException
{
    public string ErrorMessage { get; set; } = errorMessage;
}