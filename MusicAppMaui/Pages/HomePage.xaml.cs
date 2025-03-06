using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class HomePage : ContentPage
{


    public HomePage(HomePageModel homePageModel)
    {
        BindingContext = homePageModel;
        InitializeComponent();
    }

}
