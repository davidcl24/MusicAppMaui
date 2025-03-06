using CommunityToolkit.Mvvm.ComponentModel;
using MusicAppMaui.Models;
using MusicAppMaui.Rest;
using System.Collections.ObjectModel;

namespace MusicAppMaui.PageModels;

public partial class SettingsPageModel : ObservableObject
{
    private readonly RestService restService;

    public SettingsPageModel(RestService restService)
    {
        this.restService = restService;
    }


    [ObservableProperty]
    private string label = "Funciona settings";

   
}
