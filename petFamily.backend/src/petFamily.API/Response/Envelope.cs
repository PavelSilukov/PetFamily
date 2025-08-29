using petFamily.Domain.Shared;

namespace petFamily.API.Response;

public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);


public record Envelope
{
    public object? Result { get; }
    public ErrorList? Errors { get; } 
  
    public DateTime TimeGeneration { get; }

    private Envelope(object? result, ErrorList? errors)
    {
        Result = result;
        Errors = errors;
        TimeGeneration = DateTime.Now;
    }

    public static Envelope Ok(object? result = null)
    {
        return new Envelope(result, null);
    }
    public static Envelope Error(ErrorList errors)
    {
        return new Envelope(null, errors);
    }
}