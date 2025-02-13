namespace DeveloperStore.Api.Application.Exceptions;

public abstract class CustomException : Exception
{
    public int StatusCode { get; }

    protected CustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message) : base(message, 404) { }
    }
    
    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message, 400) { }
    }
    
    public class BusinessException : Exception
    {
        public BusinessException(string message, Exception? innerException = null) 
            : base(message, innerException) { }
    }
    
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception? innerException = null) 
            : base(message, innerException) { }
    }
}