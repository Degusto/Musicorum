using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;
using Podemski.Musicorum.UI.Views;

namespace Podemski.Musicorum.UI.Services
{
    public sealed class ViewService : IViewService
    {
        public void ShowView(IArtist artist)
        {
            var window = new ArtistWindow(artist);

            window.ShowDialog();
        }

        public void ShowView(IAlbum album)
        {
            var window = new AlbumWindow(album);

            window.ShowDialog();
        }

        public void ShowView(ITrack track)
        {
            var window = new TrackWindow(track);

            window.ShowDialog();
        }
    }
}
