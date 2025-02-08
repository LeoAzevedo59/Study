namespace Exception.Exceptions;

public class ErrorOnValidationException(List<string> errorMessages) : CustomException
{
    public List<string> ErrorMessages { get; set; } = errorMessages;
}