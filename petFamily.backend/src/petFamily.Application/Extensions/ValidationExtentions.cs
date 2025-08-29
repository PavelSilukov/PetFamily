using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using petFamily.Domain.Shared;

namespace petFamily.Application.Extensions;

public static class ValidationExtentions
{
    public static ErrorList ToErrorList(this ValidationResult validationResultresult)
    {
        var validationErrors = validationResultresult.Errors;
        var errors = from validationError in validationErrors
            let errorMessage = validationError.ErrorMessage
            let error = Error.Desrialize(errorMessage)
            select Error.Validation(error.Code, error.Message, validationError.PropertyName);
        return errors.ToList();
    }
}