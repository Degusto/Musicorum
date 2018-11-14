using System.Collections.Generic;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly SearchCriteria _searchCriteria;

        private readonly IViewService _viewService;
        private readonly ISearchService _searchService;
        private readonly IArtistFactory _artistFactory;
        private readonly IArtistService _artistService;

        public MainViewModel(IViewService viewService, ISearchService searchService, IArtistFactory artistFactory, IArtistService artistService)
        {
            _viewService = viewService;
            _searchService = searchService;
            _artistFactory = artistFactory;
            _artistService = artistService;
            _searchCriteria = new SearchCriteria();
        }

        public ICommand OpenArtistCommand => new RelayCommand<IArtist>(ShowView, x => x != null);

        public ICommand OpenAlbumCommand => new RelayCommand<IAlbum>(ShowView, x => x != null);

        public ICommand OpenTrackCommand => new RelayCommand<ITrack>(ShowView, x => x != null);

        public ICommand AddArtistCommand => new RelayCommand(AddArtist);

        public IEnumerable<IArtist> Artists => _searchService.FindArtists(_searchCriteria);

        public IEnumerable<IAlbum> Albums => _searchService.FindAlbum(_searchCriteria);

        public IEnumerable<ITrack> Tracks => _searchService.FindTrack(_searchCriteria);

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

        private void AddArtist()
        {
            var artist = _artistFactory.Create("Nowy");

            _artistService.Save(artist);

            ShowView(artist);
        }
    }
}