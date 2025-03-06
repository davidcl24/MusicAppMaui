using CommunityToolkit.Mvvm.ComponentModel;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;
using System.Collections.ObjectModel;

namespace MusicAppMaui.PageModels;

public partial class AlbumsPageModel : ObservableObject
{
    private readonly RestService restService;

    public AlbumsPageModel(RestService restService)
    {
        this.restService = restService;
        GetListsAsync();
    }


    [ObservableProperty]
    private string label = "Funciona albums";

    [ObservableProperty]
    private ObservableCollection<Album> _albums;

    private async void GetListsAsync()
    {
        Albums = new(await restService.GetAlbumsAsync());
    }
}
