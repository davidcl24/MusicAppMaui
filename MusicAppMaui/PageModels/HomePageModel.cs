using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;
using System.Collections.ObjectModel;

namespace MusicAppMaui.PageModels;

public partial class HomePageModel : ObservableObject
{
    private readonly RestService restService;

    public HomePageModel(RestService restService) { 
        this.restService = restService;
        GetListsAsync();
    }

    [ObservableProperty]
    private ObservableCollection<Artist> _artists;

    [ObservableProperty]
    private ObservableCollection<Album> _albums;

    [ObservableProperty]
    private Artist _selectedArtist;

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

    [RelayCommand]
    private async Task ShowArtistDetailAsync()
    {
        var selected = SelectedArtist;
        if ( selected != null)
        {
            await Shell.Current.GoToAsync($"/detailArtist?id={selected.Id}");
            SelectedArtist = null;
        }
    }


    private async void GetListsAsync()
    {
        Artists = new (await restService.GetArtistsAsync());
        Albums = new(await restService.GetAlbumsAsync());
    }

}
