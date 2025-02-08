namespace Exception.Exceptions;

public abstract class CustomException(string message) : SystemException(message);