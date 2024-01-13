using System.Text.RegularExpressions;
using YoutubeDownloaderRU.Core.Utils.Extensions;

namespace YoutubeDownloaderRU.Core.Utils;

public static class Url
{
    public static string? TryExtractFileName(string url) =>
        Regex.Match(url, @".+/([^?]*)").Groups[1].Value.NullIfEmptyOrWhiteSpace();
}
