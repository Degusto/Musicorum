using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly IViewService _viewService;
        private readonly ITrackService _trackService;

        public MainViewModel(IViewService viewService, ITrackService trackService)
        {
            _viewService = viewService;
            _trackService = trackService;
        }

        public RelayCommand<IArtist> OpenArtistCommand => new RelayCommand<IArtist>(_viewService.ShowView, x => x != null);

        public RelayCommand<IAlbum> OpenAlbumCommand => new RelayCommand<IAlbum>(_viewService.ShowView, x => x != null);

        public RelayCommand<ITrack> OpenTrackCommand => new RelayCommand<ITrack>(_viewService.ShowView, x => x != null);

        public RelayCommand OpenCommand => new RelayCommand(() => _viewService.ShowView(_trackService.Get(1)));
    }
}