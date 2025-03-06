using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;

namespace MusicAppMaui.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class AlbumDetailPageModel : ObservableObject
{
    private int _id;
    public int Id { get => _id; set { _id = value; GetAlbumAsync(); GetPlaylistsAsync(); } }
    private readonly RestService restService;
    public AlbumDetailPageModel(RestService restService)
    {
        this.restService = restService;
    }


    [ObservableProperty]
    private AlbumExtended _currentAlbum;

    [ObservableProperty]
    private Song _selectedSong;

    [ObservableProperty]
    private List<Playlist> _playLists;

    [ObservableProperty]
    private Playlist _selectedPlaylist;

    [RelayCommand]
    private async Task ShowArtistDetailAsync()
    {
        var artist = CurrentAlbum.Artist;
        if (artist != null)
        {
            await Shell.Current.GoToAsync($"/detailArtist?id={artist.Id}");
        }
    }

    [RelayCommand]
    private async Task AddSongToPlayListAsync(int selectedIndex)
    {
        if (SelectedSong != null && SelectedPlaylist != null)
        {
            List<Playlist> playlists;
            if (SelectedSong.Playlists != null)
            {
                playlists = SelectedSong.Playlists.ToList();
            } else
            {
                playlists = [];
            }
              
            playlists.Add(SelectedPlaylist);
            SelectedSong.Playlists = playlists.ToArray();
            restService.UpdateSong(SelectedSong);
        }
        SelectedPlaylist = null;
    }

    private async void GetAlbumAsync()
    {
        var album = await restService.GetAlbumByIdAsync(Id);
        if (album?.Songs is not null)
        {
            album.Songs = album.Songs.OrderBy(song => song.TrackNum).ToArray();
        }
        CurrentAlbum = album;
    }

    private async void GetPlaylistsAsync()
    {
        PlayLists = new(await restService.GetPlaylistsAsync());
    }

    
}
