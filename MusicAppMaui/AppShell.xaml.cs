using MusicAppMaui.Pages;

namespace MusicAppMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeRouting();
        }

        private void InitializeRouting()
        {
            Routing.RegisterRoute("detailAlbum", typeof(AlbumDetailPage));
            Routing.RegisterRoute("detailArtist", typeof(ArtistDetailPage));
        }
    }
}
