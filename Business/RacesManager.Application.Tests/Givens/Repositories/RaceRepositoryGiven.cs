using RacesManager.Adapters.Persistence.InMemory.Repositories;
using RacesManager.Application.Tests.Builders;
using RacesManager.Domain.Entities;


namespace RacesManager.Application.Tests.Givens.Repositories;

internal static class RaceRepositoryGiven
{
    public static Race HaveAlreadyRace(this InMemoryIRaceRepositoryRepository repositoryRepository, Action<RaceBuilder> builder)
    {
        var raceBuilder = new RaceBuilder();
        builder.Invoke(raceBuilder);
        Race race = raceBuilder.Build();
        repositoryRepository.Races.Add(race);
        return race;
    }
}
