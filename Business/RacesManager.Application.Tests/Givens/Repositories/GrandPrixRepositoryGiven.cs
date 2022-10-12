using RacesManager.Adapters.Persistence.InMemory.Repositories;
using RacesManager.Application.Tests.Builders;
using RacesManager.Domain.Entities;


namespace RacesManager.Application.Tests.Givens.Repositories;

internal static class GrandPrixRepositoryGiven
{
    public static GrandPrix HaveAlreadyGrandPrix(this InMemoryGrandPrixRepository grandPrixRepository, Action<GrandPrixBuilder> builder)
    {
        var grandPrixBuilder = new GrandPrixBuilder();
        builder(grandPrixBuilder);
        GrandPrix grandPrix = grandPrixBuilder.Build();
        grandPrixRepository.GrandPrix.Add(grandPrix);
        return grandPrix;
    }
}
