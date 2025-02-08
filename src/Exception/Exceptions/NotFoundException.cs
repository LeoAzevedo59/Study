namespace Exception.Exceptions;

public class NotFoundException(string message): CustomException(message)
{
}