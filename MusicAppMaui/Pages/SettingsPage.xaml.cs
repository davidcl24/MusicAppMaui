using MusicAppMaui.PageModels;

namespace MusicAppMaui.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel settingsPageModel)
	{
		BindingContext = settingsPageModel;
		InitializeComponent();
	}
}