namespace RacesManager.Application.Services.IcsContentCreator;

internal record IcsEvent(string Id, string Summary, string Location, DateTime StartAt, DateTime? EndAt, string Category);
