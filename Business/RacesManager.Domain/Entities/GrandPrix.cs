namespace RacesManager.Domain.Entities;

public abstract record GrandPrix(string Name, Circuit Circuit)
{
    public abstract string GetCategoryIcon();
    public abstract string GetCategoryName();

    public static GrandPrix From
    (
        Categories category,
        string name,
        Circuit circuit
    )
    {
        return category switch
        {
            Categories.F1 => new F1GrandPrix(name, circuit),
            Categories.MotoGp => new MotoGpGrandPrix(name, circuit),
            _ => throw new ArgumentException($"unknown category of {nameof(GrandPrix)}", nameof(category)),
        };
    }
    
    public enum Categories
    {
        MotoGp,
        F1,
    }
}
