namespace Exception.Exceptions;

public abstract class CustomException : SystemException
{
    public abstract string ErrorName { get; }
    public abstract int StatusCode { get; }
    public abstract List<string> GetErros();
    public abstract string GetAction();
    
    protected CustomException(string message) : base(message)
    {
        
    }
}