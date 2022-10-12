using System.Text;
using Microsoft.AspNetCore.Mvc;


namespace RacesManager.Adapters.Tests.Asserts;

internal static class FileStreamResultAssert
{
    public static void ShouldHaveContentType(this FileStreamResult fileStreamResult, string contentType)
    {
        Assert.Equal(contentType, fileStreamResult.ContentType);
    }
    
    public static async void ShouldHaveContent(this FileStreamResult fileStreamResult, string content)
    {
        using var reader = new StreamReader(fileStreamResult.FileStream, Encoding.UTF8);
        string value = await reader.ReadToEndAsync();
        Assert.Equal(content, value);
    }
}
