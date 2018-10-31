using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class TrackViewModel : ViewModelBase, IRecordViewModel
    {
        private ITrack _track;

        private readonly IViewService _viewService;
        private readonly ITrackService _trackService;

        internal TrackViewModel(IViewService viewService, ITrackService trackService)
        {
            _viewService = viewService;
            _trackService = trackService;
        }

        public void Initialize(int id)
        {
            _track = _trackService.Get(id);

            Title = _track.Title;
            AlbumName = _track.Album.Title;
            Description = _track.Description;

            RaisePropertyChanged(() => AlbumName);
        }

        public string AlbumName { get; private set; }

        public string Title
        {
            get => _track.Title;
            set
            {
                _track.Title = value;

                RaisePropertyChanged(() => Title);
            }
        }

        public string Description
        {
            get => _track.Description;
            set
            {
                _track.Description = value;

                RaisePropertyChanged(() => Description);
            }
        }

        public RelayCommand OpenAlbumCommand => new RelayCommand(() => _viewService.ShowView(_track.Album));

        public RelayCommand SaveCommand => new RelayCommand(() => _trackService.Update(_track));
    }
}
