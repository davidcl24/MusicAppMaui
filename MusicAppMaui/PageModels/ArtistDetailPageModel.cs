using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;

namespace MusicAppMaui.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class ArtistDetailPageModel : ObservableObject
{
    private int _id;
    public int Id { get => _id; set { _id = value; GetArtistAsync(); } }

    private readonly RestService restService;
    public ArtistDetailPageModel(RestService restService)
    {
        this.restService = restService;
    }


    [ObservableProperty]
    private ArtistExtended _currentArtist;

    [ObservableProperty]
    private Album _selectedAlbum;


    [RelayCommand]
    private async Task ShowAlbumDetailAsync()
    {
        var selected = SelectedAlbum;
        if (selected != null)
        {
            await Shell.Current.GoToAsync($"/detailAlbum?id={selected.Id}");
            SelectedAlbum = null;
        }
    }

    private async void GetArtistAsync()
    {
        CurrentArtist = await restService.GetArtistByIdAsync(Id);
    }

}
