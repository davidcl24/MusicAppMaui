using System.Text.Json.Serialization;

namespace MusicAppMaui.Models;

public class Artist
{
    public string? Name { get; set; }
    public string? Mbid { get; set; }

    [JsonPropertyName("artist_background")]
    public string? ArtistBackground { get; set; }

    [JsonPropertyName("artist_logo")]
    public string? ArtistLogo { get; set; }

    [JsonPropertyName("artist_thumbnail")]
    public string? ArtistThumbnail { get; set; }

    [JsonPropertyName("artist_banner")]
    public string? ArtistBanner { get; set; }
    public int? Id { get; set; }
}

public class ArtistExtended : Artist
{
    public Album[]? Albums { get; set; }
}

