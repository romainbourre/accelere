using System.Text;


namespace RacesManager.Application.Services.IcsContentCreator;

internal class IcsContentCreator
{
    private readonly string prodId;
    private readonly List<IcsEvent> icsEvents = new();

    public IcsContentCreator(string prodId)
    {
        this.prodId = prodId;
    }

    public void AddEvent(IcsEvent icsEvent)
    {
        icsEvents.Add(icsEvent);
    }

    public string Create()
    {
        string eventsContent = ComputeIcsEventsContent();
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("BEGIN:VCALENDAR");
        stringBuilder.AppendLine("VERSION:2.0");
        stringBuilder.AppendLine($"PRODID:{prodId}");
        stringBuilder.AppendLine("CALSCALE:GREGORIAN");
        stringBuilder.AppendLine("METHOD:PUBLISH");
        if (eventsContent != string.Empty)
            stringBuilder.AppendLine(eventsContent);
        stringBuilder.Append("END:VCALENDAR");
        return stringBuilder.ToString();
    }

    private string ComputeIcsEventsContent()
    {
        return $"{string.Join("\n", icsEvents.Select(ToIcsEvent))}";
    }

    private static string ToIcsEvent(IcsEvent icsEvent)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("BEGIN:VEVENT");
        stringBuilder.AppendLine($"UID:{icsEvent.Id}");
        stringBuilder.AppendLine($"{ToIcsDateTimeRange(icsEvent.StartAt, icsEvent.EndAt)}");
        stringBuilder.AppendLine($"SUMMARY:{icsEvent.Summary}");
        stringBuilder.AppendLine($"LOCATION:{icsEvent.Location}");
        stringBuilder.AppendLine($"CATEGORIES:{icsEvent.Category}");
        stringBuilder.Append("END:VEVENT");
        return stringBuilder.ToString();
    }

    private static string ToIcsDateTimeRange(DateTime startAt, DateTime? endAt)
    {
        var stringBuilder = new StringBuilder();
        if (endAt.HasValue)
        {
            stringBuilder.AppendLine($"DTSTART:{startAt.ToIcsDateTimeFormat()}");
            stringBuilder.Append($"DTEND:{endAt.Value.ToIcsDateTimeFormat()}");
            return stringBuilder.ToString();
        }
        stringBuilder.Append($"DTSTART;VALUE=DATE:{startAt.ToIcsDateFormat()}");
        return stringBuilder.ToString();
    }
}