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
    public sealed class ArtistViewModel : ViewModelBase
    {
        private IArtist _artist;

        private readonly IViewService _viewService;
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly IAlbumFactory _albumFactory;
        private readonly IDialogService _dialogService;

        internal ArtistViewModel(IViewService viewService, IArtistService artistService, IAlbumService albumService, IAlbumFactory albumFactory, IDialogService dialogService)
        {
            _viewService = viewService;
            _artistService = artistService;
            _albumService = albumService;
            _albumFactory = albumFactory;
            _dialogService = dialogService;
        }

        public void Initialize(IArtist artist)
        {
            _artist = artist;

            Name = _artist.Name;

            RaisePropertyChanged(() => Albums);
        }

        public string Name
        {
            get => _artist.Name;
            set
            {
                _artist.Name = value;

                RaisePropertyChanged(() => Name);
            }
        }

        public IEnumerable<IAlbum> Albums => _artist.Albums;

        public ICommand OpenAlbumCommand => new RelayCommand<IAlbum>(_viewService.ShowView, x => x != null);

        public ICommand DeleteAlbumCommand => new RelayCommand<IAlbum>(DeleteAlbum, x => x != null);

        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(DeleteArtist);

        public ICommand AddAlbumCommand => new RelayCommand(AddAlbum);

        private void Save()
        {
            if(!_dialogService.ShowQuestion("Chcesz zapisać zmiany?"))
            {
                return;
            }

            _artistService.Save(_artist);

            _dialogService.ShowInfo("Zapisano.");
        }

        private void DeleteAlbum(IAlbum album)
        {
            if (!_dialogService.ShowQuestion("Chcesz usunąć obiekt?"))
            {
                return;
            }

            _albumService.Delete(album);

            _dialogService.ShowInfo("Usunięto.");

            RaisePropertyChanged(() => Albums);
        }

        private void DeleteArtist()
        {
            if (!_dialogService.ShowQuestion("Chcesz usunąć obiekt?"))
            {
                return;
            }

            _artistService.Delete(_artist);

            _dialogService.ShowInfo("Usunięto.");

            _viewService.CloseEntityView();
        }

        private void AddAlbum()
        {
            var album = _albumFactory.Create(_artist, "Nowy", Genre.All, false, string.Empty);

            _albumService.Save(album);

            _viewService.ShowView(album);
        }
    }
}
