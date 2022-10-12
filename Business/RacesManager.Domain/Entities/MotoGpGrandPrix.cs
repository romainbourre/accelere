namespace RacesManager.Domain.Entities;

public record MotoGpGrandPrix(string Name, Circuit circuit) : GrandPrix(Name, circuit)
{

    public override string GetCategoryIcon()
    {
        return "🏍";
    }
    public override string GetCategoryName()
    {
        return "MotoGP";
    }
}
