using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using petFamily.Application.Voluntreers.CreateVolunteer;
using petFamily.Domain.PetManagement.ValueObjects;


namespace petFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

}

