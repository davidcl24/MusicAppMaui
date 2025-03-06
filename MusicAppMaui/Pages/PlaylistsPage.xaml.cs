using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class PlaylistsPage : ContentPage
{
	public PlaylistsPage(PlaylistsPageModel playlistsPageModel)
	{
		BindingContext = playlistsPageModel;
		InitializeComponent();
	}
}