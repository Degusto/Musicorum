using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class TrackViewModel : ViewModelBase, IRecordViewModel
    {
        private string _title;
        private string _description;
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
