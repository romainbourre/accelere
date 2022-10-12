using Microsoft.AspNetCore.Mvc;
using RacesManager.Application.Ports;


namespace RacesManager.Adapters.Controllers;

public abstract class RaceIcsCalendarController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetIcsCalendar([FromServices] IGetRaceIcsCalendarUseCase useCase)
    {
        string response = await useCase.Handle();
        Response.Headers.Add("content-disposition", "attachment; filename=\"races.ics\"");
        return CreateCalendarFile(response);
    }

    private static FileStreamResult CreateCalendarFile(string content)
    {
        Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        return new FileStreamResult(GenerateStreamFromString(content), "text/calendar");
    }
}
