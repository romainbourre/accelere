using RacesManager.Application.Ports;
using RacesManager.Application.Services.IcsContentCreator;
using RacesManager.Domain.Entities;


namespace RacesManager.Application.UseCases.GetRaceEvents;

public class GetRaceIcsCalendarUseCase : IGetRaceIcsCalendarUseCase
{
    private readonly IRacesRepository racesRepository;
    private readonly IcsContentCreator icsContentCreator = new("romainbourre.fr");

    public GetRaceIcsCalendarUseCase(IRacesRepository racesRepository)
    {
        this.racesRepository = racesRepository;
    }

    public async Task<string> Handle()
    {
        IEnumerable<Race> raceList = await racesRepository.All();
        AddRacesToIcs(raceList);
        return icsContentCreator.Create();
    }

    private void AddRacesToIcs(IEnumerable<Race> raceList)
    {
        foreach (Race race in raceList)
        {
            IcsEvent icsEvent = CreateIcsEventFromRace(race);
            icsContentCreator.AddEvent(icsEvent);
        }
    }

    private static IcsEvent CreateIcsEventFromRace(Race race)
    {
        return new IcsEvent(
            race.Id.ToString(),
            race.GetName(),
            race.GrandPrix.Circuit.ToString(),
            race.StartAt,
            race.EndAt,
            race.GrandPrix.GetCategoryName()
        );
    }
}