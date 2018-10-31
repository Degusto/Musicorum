using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly IViewService _viewService;

        public MainViewModel(IViewService viewService)
        {
            _viewService = viewService;
        }

        public RelayCommand<IArtist> OpenArtistCommand => new RelayCommand<IArtist>(_viewService.ShowView, x => x != null);

        public RelayCommand<IAlbum> OpenAlbumCommand => new RelayCommand<IAlbum>(_viewService.ShowView, x => x != null);

        public RelayCommand<ITrack> OpenTrackCommand => new RelayCommand<ITrack>(_viewService.ShowView, x => x != null);

        public RelayCommand OpenCommand => new RelayCommand(() => _viewService.ShowView(new Track()));
    }

    class Track : ITrack
    {
        public Track()
        {
            Title = "TRACK";
            Description = "OPIS2";
        }
        public IAlbum Album => new Album();

        public string Title { get ; set ; }
        public string Description { get;set; }

        public int Id => 0;

        public override string ToString() => $"{Album.Title} - {Title}";
    }

    class Album : IAlbum
    {
        public Album()
        {
            Title = "ALBUM";
            Description = "OPIS";
        }
        public IArtist Artist => throw new System.NotImplementedException();

        public string Title { get ; set ; }
        public Genre Genre { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsDigital { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsForeign { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Description { get; set; }
        public IEnumerable<ITrack> TrackList { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Id => throw new System.NotImplementedException();
    }
}