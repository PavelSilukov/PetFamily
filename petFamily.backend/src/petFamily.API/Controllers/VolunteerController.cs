using System.Collections.Generic;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using petFamily.API.Extentions;
using petFamily.API.Response;
using petFamily.Application.Volunteers.CreateVolunteer;
using petFamily.Domain.Shared;

namespace petFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromServices] IValidator<CreateVolunteerRequest> validator,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors);
        }
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();
        return Ok(Envelope.Ok(result.Value));

    }

}

