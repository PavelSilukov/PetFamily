using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using petFamily.Domain.Volunteers;


namespace petFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
 public IActionResult Get(string description)
 {
  Result<Volunteer> volunteer = Volunteer.Create(description);
  return Ok();
 }
}

