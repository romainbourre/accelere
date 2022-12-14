using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using System.Text;

namespace RacesManager.Api.Responses;

[ExcludeFromCodeCoverage]
internal static class ResultsExtensions
{
    public static IResult Html(this IResultExtensions resultExtensions, string html)
    {
        ArgumentNullException.ThrowIfNull(resultExtensions);
        return new HtmlResult(html);
    }
}

[ExcludeFromCodeCoverage]
internal class HtmlResult : IResult
{
    private readonly string html;

    public HtmlResult(string html)
    {
        this.html = html;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
        return httpContext.Response.WriteAsync(html);
    }
}