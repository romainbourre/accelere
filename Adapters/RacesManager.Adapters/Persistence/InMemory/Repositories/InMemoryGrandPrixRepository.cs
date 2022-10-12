using RacesManager.Domain.Entities;


namespace RacesManager.Adapters.Persistence.InMemory.Repositories;

public class InMemoryGrandPrixRepository
{
    public readonly List<GrandPrix> GrandPrix = new();
}
