namespace RacesManager.Application.Ports;

public interface IGetRaceIcsCalendarUseCase
{
    public Task<string> Handle();
}
