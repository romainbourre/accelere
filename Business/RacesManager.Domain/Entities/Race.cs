namespace RacesManager.Domain.Entities;

public record Race(
    Guid Id,
    string Name,
    DateTime StartAt,
    DateTime? EndAt,
    GrandPrix GrandPrix
)
{
    public readonly Guid Id = Id;
    public readonly string Name = Name;
    public readonly DateTime StartAt = StartAt;
    public readonly DateTime? EndAt = EndAt;
    public readonly GrandPrix GrandPrix = GrandPrix;

    public string GetName()
    {
        return $"{GrandPrix.GetCategoryIcon()} {Name} ({GrandPrix.Name})";
    }
}
