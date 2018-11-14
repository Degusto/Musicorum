using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class TrackViewModel : ViewModelBase
    {
        private ITrack _track;

        private readonly IViewService _viewService;
        private readonly ITrackService _trackService;
        private readonly IDialogService _dialogService;

        internal TrackViewModel(IViewService viewService, ITrackService trackService, IDialogService dialogService)
        {
            _viewService = viewService;
            _trackService = trackService;
            _dialogService = dialogService;
        }

        public void Initialize(ITrack track)
        {
            _track = track;

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

        public RelayCommand SaveCommand => new RelayCommand(Save);

        private void Save()
        {
            if (!_dialogService.ShowQuestion("Chcesz zapisać zmiany?"))
            {
                return;
            }

            _trackService.Save(_track);

            _dialogService.ShowInfo("Zapisano.");
        }
    }
}
