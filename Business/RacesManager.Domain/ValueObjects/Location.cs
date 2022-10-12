namespace RacesManager.Domain.ValueObjects;

public readonly struct Location
{
    public readonly string icon;
    private readonly string country;

    public Location(string icon, string country)
    {
        this.icon = icon;
        this.country = country;
    }
    public override string ToString()
    {
        return icon;
    }
}
