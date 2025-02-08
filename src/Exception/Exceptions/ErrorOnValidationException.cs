namespace Exception.Exceptions;

public class ErrorOnValidationException(List<string> errorMessages) : CustomException(string.Empty)
{
    public List<string> ErrorMessages { get; set; } = errorMessages;
}