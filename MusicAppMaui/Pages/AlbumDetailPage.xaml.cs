using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class AlbumDetailPage : ContentPage
{
	public AlbumDetailPage(AlbumDetailPageModel albumDetailPageModel)
	{
		BindingContext = albumDetailPageModel;
		InitializeComponent();
	}
}