using petFamily.Domain.Shared;

namespace petFamily.API.Response;

public record ResponseError(string? ErrorCode, string? ErrorMessage, string? InvalidField);


public record Envelope
{
    public object? Result { get; }
    public List<ResponseError> Errors { get; } 
  
    public DateTime TimeGeneration { get; }

    private Envelope(object? result, IEnumerable<ResponseError>? errors)
    {
        Result = result;
        Errors = errors.ToList();
        TimeGeneration = DateTime.Now;
    }

    public static Envelope Ok(object? result = null)
    {
        return new Envelope(result, []);
    }
    public static Envelope Error(IEnumerable<ResponseError> errors)
    {
        return new Envelope(null, errors);
    }
}