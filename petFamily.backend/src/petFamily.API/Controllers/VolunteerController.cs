using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using petFamily.API.Extentions;
using petFamily.API.Response;
using petFamily.Application.Volunteers.CreateVolunteer;

namespace petFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure)
            return result.Error.ToResponse();
        return Ok(Envelope.Ok(result.Value));

    }

}

