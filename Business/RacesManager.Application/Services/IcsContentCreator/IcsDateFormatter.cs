namespace RacesManager.Application.Services.IcsContentCreator;

internal static class IcsDateFormatter
{
    public static string ToIcsDateTimeFormat(this DateTime date)
    {
        return $"{date:yyyy}{date:MM}{date:dd}T{date:HH}{date:mm}00";
    }

    public static string ToIcsDateFormat(this DateTime date)
    {
        return $"{date.Date:yyyyMMdd}";
    }
}
