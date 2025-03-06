using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class AlbumDetailPage : ContentPage
{
	public AlbumDetailPage(AlbumDetailPageModel albumDetailPageModel)
	{
		BindingContext = albumDetailPageModel;
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (BindingContext is AlbumDetailPageModel viewModel && sender is Picker picker)
        {
            if (viewModel.AddSongToPlayListCommand != null && viewModel.AddSongToPlayListCommand.CanExecute(picker.SelectedIndex))
            {
                viewModel.AddSongToPlayListCommand.Execute(picker.SelectedIndex);
            }
        }
    }
}