using System.Collections.Generic;
using YoutubeExplode.Videos;

namespace YoutubeDownloaderRU.Core.Resolving;

public record QueryResult(QueryResultKind Kind, string Title, IReadOnlyList<IVideo> Videos);
