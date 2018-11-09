using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class AlbumViewModel : ViewModelBase, IRecordViewModel
    {
        private IAlbum _album;

        private readonly IViewService _viewService;
        private readonly IAlbumService _albumService;
        private readonly IDialogService _dialogService;

        internal AlbumViewModel(IViewService viewService, IAlbumService albumService, IDialogService dialogService)
        {
            _viewService = viewService;
            _albumService = albumService;
            _dialogService = dialogService;
        }

        public void Initialize(int id)
        {
            _album = _albumService.Get(id);

            Title = _album.Title;
            ArtistName = _album.Artist.Name;
            Description = _album.Description;
            IsDigital = _album.IsDigital;
            Genre = _album.Genre;

            RaisePropertyChanged(() => ArtistName);
            RaisePropertyChanged(() => Tracks);
        }

        public string ArtistName { get; private set; }

        public string Title
        {
            get => _album.Title;
            set
            {
                _album.Title = value;

                RaisePropertyChanged(() => Title);
            }
        }

        public string Description
        {
            get => _album.Description;
            set
            {
                _album.Description = value;

                RaisePropertyChanged(() => Description);
            }
        }

        public bool IsDigital
        {
            get => _album.IsDigital;
            set
            {
                _album.IsDigital = value;

                RaisePropertyChanged(() => IsDigital);
            }
        }

        public Genre Genre
        {
            get => _album.Genre;
            set
            {
                _album.Genre = value;

                RaisePropertyChanged(() => Genre);
            }
        }

        public IEnumerable<ITrack> Tracks => _album.TrackList;

        public RelayCommand OpenArtistCommand => new RelayCommand(() => _viewService.ShowView(_album.Artist));

        public RelayCommand<ITrack> OpenTrackCommand => new RelayCommand<ITrack>(_viewService.ShowView, x => x != null);

        public RelayCommand SaveCommand => new RelayCommand(Update);

        private void Update()
        {
            if (!_dialogService.ShowQuestion("Chcesz zapisać zmiany?"))
            {
                return;
            }

            _albumService.Update(_album);

            _dialogService.ShowInfo("Zapisano.");
        }
    }
}
