using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicAppMaui.Models;
using MusicAppMaui.Pages;
using MusicAppMaui.Rest;
using System.Collections.ObjectModel;

namespace MusicAppMaui.PageModels;

public partial class PlaylistsPageModel : ObservableObject
{
    private readonly RestService restService;


    public PlaylistsPageModel(RestService restService)
    {
        this.restService = restService;
        GetListsAsync();
    }

    [ObservableProperty]
    private string _label = "Funciona listas";

    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists;

    [RelayCommand]
    private async void ShowPopup()
    {
        var popup = new CustomPopupPage();
        var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);

        if (result is (string name, string desc)) 
        {
            restService.PostPlaylistAsync(new Playlist{Title=name, Description=desc});
           
        }
    }

    private async void GetListsAsync()
    {
        Playlists = new(await restService.GetPlaylistsAsync());
    }
}
