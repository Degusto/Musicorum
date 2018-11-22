using System.Collections.Generic;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class AlbumViewModel : ViewModelBase
    {
        private IAlbum _album;

        private readonly IViewService _viewService;
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;
        private readonly ITrackFactory _trackFactory;
        private readonly IDialogService _dialogService;

        internal AlbumViewModel(IViewService viewService, IAlbumService albumService, ITrackService trackService, ITrackFactory trackFactory, IDialogService dialogService)
        {
            _viewService = viewService;
            _albumService = albumService;
            _trackService = trackService;
            _trackFactory = trackFactory;
            _dialogService = dialogService;
        }

        public void Initialize(IAlbum album)
        {
            _album = album;

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

        public IEnumerable<ITrack> Tracks => _album.Tracks;

        public ICommand OpenArtistCommand => new RelayCommand(() => _viewService.ShowView(_album.Artist));

        public ICommand OpenTrackCommand => new RelayCommand<ITrack>(_viewService.ShowView, x => x != null);

        public ICommand DeleteTrackCommand => new RelayCommand<ITrack>(DeleteTrack, x => x != null);

        public ICommand AddTrackCommand => new RelayCommand(AddTrack);

        public RelayCommand SaveCommand => new RelayCommand(Save);

        private void Save()
        {
            if (!_dialogService.ShowQuestion("Chcesz zapisać zmiany?"))
            {
                return;
            }

            _albumService.Save(_album);

            _dialogService.ShowInfo("Zapisano.");
        }

        private void DeleteTrack(ITrack track)
        {
            if (!_dialogService.ShowQuestion("Chcesz usunąć obiekt?"))
            {
                return;
            }

            _trackService.Delete(track);

            _dialogService.ShowInfo("Usunięto.");

            RaisePropertyChanged(() => Tracks);
        }

        private void AddTrack()
        {
            var track = _trackFactory.Create(_album, "Nowy", string.Empty);

            _trackService.Save(track);

            _viewService.ShowView(track);
        }
    }
}
