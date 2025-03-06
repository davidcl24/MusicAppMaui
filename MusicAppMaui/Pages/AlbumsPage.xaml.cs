using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class AlbumsPage : ContentPage
{
	public AlbumsPage(AlbumsPageModel albumsPageModel)
	{
		BindingContext = albumsPageModel;
		InitializeComponent();
	}
}