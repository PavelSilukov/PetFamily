using petFamily.Domain.Shared;

namespace petFamily.API.Response;

public record Envelope
{
    public object? Result { get; }
    public string? ErrorCode { get; }
    public string? ErrorMessage { get; }
    public DateTime TimeGeneration { get; }

    private Envelope(object? result, Error? error)
    {
        Result = result;
        ErrorCode = error?.Code;
        ErrorMessage = error?.Message;
        TimeGeneration = DateTime.Now;
    }

    public static Envelope Ok(object? result = null)
    {
        return new Envelope(result, null);
    }
    public static Envelope Error(Error error)
    {
        return new Envelope(null, error);
    }
}