namespace UtilityBilling.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}