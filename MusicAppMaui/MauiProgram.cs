using Microsoft.Extensions.Logging;
using MusicAppMaui.Constants;
using MusicAppMaui.PageModels;
using MusicAppMaui.Pages;
using MusicAppMaui.Rest;
using CommunityToolkit.Maui;
using Microsoft.UI.Xaml.Controls;


namespace MusicAppMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
            });

        builder.Services.AddScoped<HomePageModel>();
        builder.Services.AddScoped<PlaylistsPageModel>();
        builder.Services.AddScoped<AlbumsPageModel>();
        builder.Services.AddScoped<AlbumDetailPageModel>();
        builder.Services.AddScoped<ArtistDetailPageModel>();
        builder.Services.AddScoped<ArtistDetailPage>();
        builder.Services.AddScoped<AlbumDetailPage>();
        builder.Services.AddTransient<AlbumsPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<PlaylistsPage>();
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<RestService>(sp => new (Consts.BASE_URL, sp.GetRequiredService<HttpClient>()));

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
        {
#if WINDOWS
            if (handler.PlatformView is ComboBox comboBox)
            {
                comboBox.BorderThickness = new Microsoft.UI.Xaml.Thickness(0); 
                comboBox.Background = null; 
            }
#elif ANDROID
            handler.PlatformView.Background = null; 
#elif IOS
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; 
#endif
        });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
