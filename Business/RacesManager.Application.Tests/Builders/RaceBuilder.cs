using RacesManager.Domain.Entities;


namespace RacesManager.Application.Tests.Builders;

internal class RaceBuilder
{
    private Guid id = Guid.NewGuid();
    private string name = "Name of race";
    private string country = "Country of race";
    private DateTime startAt = DateTime.UtcNow;
    private DateTime? endAt = DateTime.UtcNow.AddHours(2);
    private GrandPrix grandPrix = new GrandPrixBuilder().Build();

    public Race Build()
    {
        return new Race(id, name, startAt, endAt, grandPrix);
    }
    public RaceBuilder WithName(string nameOfRace)
    {
        name = nameOfRace;
        return this;
    }
    public RaceBuilder EndAt(string? endOfRace)
    {
        endAt = endOfRace == null ? null : DateTime.Parse(endOfRace);
        return this;
    }
    public RaceBuilder ForGrandPrix(GrandPrix grandPrixOfRace)
    {
        grandPrix = grandPrixOfRace;
        return this;
    }
}
