using Microsoft.AspNetCore.Mvc;
using petFamily.API.Response;
using petFamily.Domain.Shared;

namespace petFamily.API.Extentions;

public static class ResponseExtentions
{
    public static ActionResult ToResponse(this Error error)
    {
        var statusCode = GetStatusCodeForErrorType(error.Type);
       
        var envelope = Envelope.Error(error.ToErrorList());
        return new ObjectResult(error)
        {
            StatusCode = statusCode
        };
    }
    
    public static ActionResult ToResponse(this ErrorList errors)
    {
        if (!errors.Any())
        {
            return new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
        
        var distinctErrors = errors
            .Select(x=>x.Type)
            .Distinct()
            .ToList();

        var statusCode = distinctErrors.Count > 1
            ? StatusCodes.Status500InternalServerError
            : GetStatusCodeForErrorType(distinctErrors.First());
    
        var envelope = Envelope.Error(errors);
        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    }

    public static int GetStatusCodeForErrorType(ErrorType errorType)
    {
        switch (errorType)
        {
            case ErrorType.Validation: return StatusCodes.Status400BadRequest;
            case ErrorType.NotFound: return StatusCodes.Status404NotFound;
            case ErrorType.Conflict: return StatusCodes.Status409Conflict;
            case ErrorType.Failure: return StatusCodes.Status500InternalServerError;
                default: return StatusCodes.Status500InternalServerError;
        };
    }
}