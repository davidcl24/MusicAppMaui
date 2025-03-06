using System.Text.Json.Serialization;

namespace MusicAppMaui.Models;

public class Album
{
    public string? Title { get; set; }
    public int? Year { get; set; }
    public string? Picture { get; set; }
    public string? Mbid { get; set; }

    [JsonPropertyName("artist_id")]
    public int? ArtistId { get; set; }
    public int? Id { get; set; }
    
}

public class AlbumExtended : Album
{
    public Artist? Artist { get; set; }
    public Song[]? Songs { get; set; }
}

