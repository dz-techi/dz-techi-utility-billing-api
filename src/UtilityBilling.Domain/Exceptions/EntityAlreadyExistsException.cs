namespace UtilityBilling.Domain.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException(string message)
    {
        Message = message;
    }

    public override string Message { get; }
}