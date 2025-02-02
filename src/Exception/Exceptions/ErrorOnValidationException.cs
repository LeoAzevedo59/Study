namespace Exception.Exceptions;

public class ErrorOnValidationException : CustomException
{
    public List<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}