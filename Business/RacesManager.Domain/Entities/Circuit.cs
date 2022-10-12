using RacesManager.Domain.ValueObjects;


namespace RacesManager.Domain.Entities;

public record Circuit(string Name, Location Location)
{
    public override string ToString()
    {
        return $"Circuit de {Name} {Location.ToString()}";
    }
}
