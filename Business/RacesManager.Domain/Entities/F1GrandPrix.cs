namespace RacesManager.Domain.Entities;

public record F1GrandPrix(string Name, Circuit circuit) : GrandPrix(Name, circuit)
{
    
    public override string GetCategoryIcon()
    {
        return "🏎";
    }
    public override string GetCategoryName()
    {
        return "F1";
    }
}
