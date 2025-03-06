using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;

namespace MusicAppMaui.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class AlbumDetailPageModel : ObservableObject
{
    private int _id;
    public int Id { get => _id; set { _id = value; GetAlbumAsync(); } }
    private readonly RestService restService;
    public AlbumDetailPageModel(RestService restService)
    {
        this.restService = restService;
    }


    [ObservableProperty]
    private AlbumExtended _currentAlbum;

    [ObservableProperty]
    private Song _selectedSong;

    [RelayCommand]
    private async Task ShowArtistDetailAsync()
    {
        var artist = CurrentAlbum.Artist;
        if (artist != null)
        {
            await Shell.Current.GoToAsync($"/detailArtist?id={artist.Id}");
        }
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
}
