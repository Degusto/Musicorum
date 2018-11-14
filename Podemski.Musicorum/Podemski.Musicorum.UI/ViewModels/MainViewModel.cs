using System.Collections.Generic;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly SearchCriteria _searchCriteria;

        private readonly IViewService _viewService;
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;

        public MainViewModel(IViewService viewService, IArtistService artistService, IAlbumService albumService, ITrackService trackService)
        {
            _viewService = viewService;
            _artistService = artistService;
            _albumService = albumService;
            _trackService = trackService;

            _searchCriteria = new SearchCriteria();
        }

        public RelayCommand<IArtist> OpenArtistCommand => new RelayCommand<IArtist>(ShowView, x => x != null);

        public RelayCommand<IAlbum> OpenAlbumCommand => new RelayCommand<IAlbum>(ShowView, x => x != null);

        public RelayCommand<ITrack> OpenTrackCommand => new RelayCommand<ITrack>(ShowView, x => x != null);

        public RelayCommand SearchCommand => new RelayCommand(Search);

        public IEnumerable<IArtist> Artists => _artistService.Find(_searchCriteria);

        public IEnumerable<IAlbum> Albums =>  _albumService.Find(_searchCriteria);

        public IEnumerable<ITrack> Tracks => _trackService.Find(_searchCriteria);

        public string Name
        {
            get => _searchCriteria.Name;
            set
            {
                _searchCriteria.Name = value;

                RaisePropertyChanged(() => Name);

                Search();
            }
        }

        public Genre Genre
        {
            get => _searchCriteria.Genre;
            set
            {
                _searchCriteria.Genre = value;

                RaisePropertyChanged(() => Genre);

                Search();
            }
        }

        public AlbumVersion AlbumVersion
        {
            get => _searchCriteria.AlbumVersion;
            set
            {
                _searchCriteria.AlbumVersion = value;

                RaisePropertyChanged(() => AlbumVersion);

                Search();
            }
        }

        private void ShowView(IEntity entity)
        {
            _viewService.ShowView(entity);

            Search();
        }

        private void Search()
        {
            RaisePropertyChanged(() => Artists);
            RaisePropertyChanged(() => Albums);
            RaisePropertyChanged(() => Tracks);
        }
    }
}