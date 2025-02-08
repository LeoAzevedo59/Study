namespace Exception.Exceptions;

public class EnvironmentVariablesEmpty(string errorMessage) : CustomException(errorMessage) { }