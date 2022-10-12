using RacesManager.Domain.Entities;
using RacesManager.Domain.ValueObjects;


namespace RacesManager.Application.Tests.Builders;

internal class GrandPrixBuilder
{
    private GrandPrix.Categories category = GrandPrix.Categories.MotoGp;
    private string name = "Mon grand prix";
    private Circuit circuit = new("A circuit", new Location("icon", "A country"));
    
    public GrandPrix Build()
    {
        return GrandPrix.From(category, name, circuit);
    }
    public GrandPrixBuilder ForCategory(GrandPrix.Categories categoryOfGrandPrix)
    {
        category = categoryOfGrandPrix;
        return this;
    }
    public GrandPrixBuilder OnCircuit(Circuit circuitOfGrandPrix)
    {
        circuit = circuitOfGrandPrix;
        return this;
    }
}
