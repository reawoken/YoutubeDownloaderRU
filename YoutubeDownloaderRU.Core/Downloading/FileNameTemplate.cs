using System;
using YoutubeDownloaderRU.Core.Utils;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloaderRU.Core.Downloading;

public static class FileNameTemplate
{
    public static string Apply(
        string template,
        IVideo video,
        Container container,
        string? number = null
    ) =>
        PathEx.EscapeFileName(
            template
                .Replace("$numc", number ?? "", StringComparison.Ordinal)
                .Replace("$num", number is not null ? $"[{number}]" : "", StringComparison.Ordinal)
                .Replace("$id", video.Id, StringComparison.Ordinal)
                .Replace("$title", video.Title, StringComparison.Ordinal)
                .Replace("$author", video.Author.ChannelTitle, StringComparison.Ordinal)
                .Replace(
                    "$uploadDate",
                    (video as Video)?.UploadDate.ToString("yyyy-MM-dd") ?? "",
                    StringComparison.Ordinal
                )
                .Trim()
                + '.'
                + container.Name
        );
}
