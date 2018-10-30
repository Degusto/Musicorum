using Ninject;

using Podemski.Musicorum.UI.Bootstrap;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class ViewModelLocator
    {
        public MainViewModel MainViewModel => Kernel.Instance.Get<MainViewModel>();

        public ArtistViewModel ArtistViewModel => Kernel.Instance.Get<ArtistViewModel>();

        public AlbumViewModel AlbumViewModel => Kernel.Instance.Get<AlbumViewModel>();

        public TrackViewModel TrackViewModel => Kernel.Instance.Get<TrackViewModel>();
    }
}