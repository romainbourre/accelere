using RacesManager.Application.Ports;
using RacesManager.Domain.Entities;


namespace RacesManager.Adapters.Persistence.InMemory.Repositories;

public class InMemoryIRaceRepositoryRepository : IRacesRepository
{

    public readonly List<Race> Races = new();
    public Task<IEnumerable<Race>> All()
    {
        return Task.FromResult<IEnumerable<Race>>(Races);
    }
}
