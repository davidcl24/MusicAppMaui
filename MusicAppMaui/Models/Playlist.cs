namespace MusicAppMaui.Models;

public class Playlist
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Id { get; set; }
}

public class PlaylistExtended : Playlist
{
    public Song[]? songs { get; set; }
}

