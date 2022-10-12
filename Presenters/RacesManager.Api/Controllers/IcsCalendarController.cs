using Microsoft.AspNetCore.Mvc;
using RacesManager.Adapters.Controllers;


namespace RacesManager.Api.Controllers;

[ApiController]
[Route("calendar")]
public class IcsCalendarController : RaceIcsCalendarController
{
}
