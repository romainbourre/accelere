using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RacesManager.Adapters.Controllers;
using RacesManager.Adapters.Tests.Asserts;
using RacesManager.Application.Ports;
using RacesManager.Application.UseCases.GetRaceEvents;


namespace RacesManager.Adapters.Tests.Controllers;


public class FakeController : RaceIcsCalendarController
{
    
}


public class RaceIcsCalendarControllerTests
{
    private readonly RaceIcsCalendarController controller;

    protected RaceIcsCalendarControllerTests()
    {
        controller = new FakeController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext(),
            },
        };
    }

    public class GivenIcsCalendar : RaceIcsCalendarControllerTests
    {
        [Fact]
        public async void ShouldReturnOkResultWithIcsHeaderAndContent()
        {
            const string expectedCalendar = "ics file content";
            var useCaseMock = new Mock<IGetRaceIcsCalendarUseCase>();
            useCaseMock.Setup(u => u.Handle()).ReturnsAsync(expectedCalendar);

            IActionResult response = await controller.GetIcsCalendar(useCaseMock.Object);

            Assert.Equal("attachment; filename=\"races.ics\"" ,controller.Response.Headers["content-disposition"]);
            var fileResult = Assert.IsType<FileStreamResult>(response);
            fileResult.ShouldHaveContentType("text/calendar");
            fileResult.ShouldHaveContent(expectedCalendar);
        }
    }
}
