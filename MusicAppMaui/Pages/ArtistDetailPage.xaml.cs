using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class ArtistDetailPage : ContentPage
{
	public ArtistDetailPage(ArtistDetailPageModel artistDetailPageModel)
	{
		BindingContext = artistDetailPageModel;
		InitializeComponent();
	}
}