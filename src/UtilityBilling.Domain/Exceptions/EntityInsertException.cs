namespace UtilityBilling.Domain.Exceptions;

public class EntityInsertException : Exception
{
    public EntityInsertException() { }

    public EntityInsertException(string message) : base(message) { }

    public EntityInsertException(string message, Exception innerException)
        : base(message, innerException) { }
}