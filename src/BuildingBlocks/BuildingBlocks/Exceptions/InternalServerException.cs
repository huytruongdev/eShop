namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string message) : base(message)
    {

    }

    public InternalServerException(string name, string details) : base(name)
    {
        Details = details;
    }

    public string? Details { get; }
}
