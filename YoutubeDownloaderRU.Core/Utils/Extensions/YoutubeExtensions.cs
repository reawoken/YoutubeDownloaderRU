using System.IO;
using YoutubeExplode.Common;

namespace YoutubeDownloaderRU.Core.Utils.Extensions;

public static class YoutubeExtensions
{
    public static string? TryGetImageFormat(this Thumbnail thumbnail) =>
        Url.TryExtractFileName(thumbnail.Url)?.Pipe(Path.GetExtension)?.Trim('.');
}
