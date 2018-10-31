using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class TrackViewModel : ViewModelBase
    {
        private string _title;
        private string _description;
        private ITrack _track;

        private readonly IViewService _viewService;
        private readonly IAlbumService _albumService;

        internal TrackViewModel(IViewService viewService, IAlbumService albumService)
        {
            _viewService = viewService;
            _albumService = albumService;
        }

        internal void Initialize(ITrack track)
        {
            _track = track;

            Title = track.Title;
            AlbumName = track.Album.Title;
            Description = track.Description;

            RaisePropertyChanged(() => AlbumName);
        }

        public string AlbumName { get; private set; }

        public string Title
        {
            get => _title;
            set => Set(() => Title, ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => Set(() => Description, ref _description, value);
        }

        public RelayCommand OpenAlbumCommand => new RelayCommand(() => _viewService.ShowView(_track.Album));
    }
}
