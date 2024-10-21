namespace TNN.Domain.Exceptions;
public class DomainException : Exception
{
    public DomainException(string message = "Invalid values") : base(message)
    {
        
    }
}
