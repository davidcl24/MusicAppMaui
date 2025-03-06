using System.Text.Json.Serialization;

namespace MusicAppMaui.Models;

public class Song
{

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("track_num")]
    public int? TrackNum { get; set; }

    [JsonPropertyName("file")]
    public string? File { get; set; }

    [JsonPropertyName("album_id")]
    public int? AlbumId { get; set; }

    [JsonPropertyName("genre_id")]
    public int? GenreId { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("album")]
    public Album? Album { get; set; }

    [JsonPropertyName("genre")]
    public Genre? Genre { get; set; }

    [JsonPropertyName("playlists")]
    public Playlist[]? Playlists { get; set; }
}

