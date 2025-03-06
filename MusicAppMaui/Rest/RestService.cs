using MusicAppMaui.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace MusicAppMaui.Rest;

public class RestService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _serializerOptions;


    public RestService(string baseUrl, HttpClient client)
    {
        this._baseUrl = baseUrl;
        this._client = client;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<Song>> GetSongsAsync() => await _client.GetFromJsonAsync<List<Song>>($"{_baseUrl}songs");

    public async Task<Song> GetSongByIdAsync(int id) => await _client.GetFromJsonAsync<Song>($"{_baseUrl}songs/{id}");

    public async void UpdateSong(Song song) => await _client.PatchAsJsonAsync<Song>($"{_baseUrl}songs/{song.Id}", song);
    
    public async void UpdateSongPlaylist(Song song, Playlist playlist) => await _client.PatchAsJsonAsync<Playlist>($"{_baseUrl}songs/{song.Id}/playlists/{playlist.Id}", playlist);

    public async Task<List<Playlist>> GetSongPlaylistsAsync(int id) => await _client.GetFromJsonAsync<List<Playlist>>($"{_baseUrl}songs/{id}/playlists");

    public async Task<List<Playlist>> GetPlaylistsAsync() => await _client.GetFromJsonAsync<List<Playlist>>($"{_baseUrl}playlists");
 
    public async Task<Playlist> GetPlaylistByIdAsync(int id) => await _client.GetFromJsonAsync<Playlist>($"{_baseUrl}playlists/{id}");

    public async Task<HttpResponseMessage> PostPlaylistAsync(Playlist playlist) => await _client.PostAsJsonAsync<Playlist>($"{_baseUrl}playlists", playlist);

    public async Task<List<AlbumExtended>> GetAlbumsAsync() => await _client.GetFromJsonAsync<List<AlbumExtended>>($"{_baseUrl}albums");

    public async Task<AlbumExtended> GetAlbumByIdAsync(int id) => await _client.GetFromJsonAsync<AlbumExtended>($"{_baseUrl}albums/{id}");

    public async Task<List<Artist>> GetArtistsAsync() => await _client.GetFromJsonAsync<List<Artist>>($"{_baseUrl}artists");

    public async Task<ArtistExtended> GetArtistByIdAsync(int id) => await _client.GetFromJsonAsync<ArtistExtended>($"{_baseUrl}artists/{id}");


}
