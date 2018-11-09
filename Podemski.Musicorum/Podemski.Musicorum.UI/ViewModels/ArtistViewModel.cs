﻿using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class ArtistViewModel : ViewModelBase, IRecordViewModel
    {
        private IArtist _artist;

        private readonly IViewService _viewService;
        private readonly IArtistService _artistService;
        private readonly IDialogService _dialogService;

        internal ArtistViewModel(IViewService viewService, IArtistService artistService, IDialogService dialogService)
        {
            _viewService = viewService;
            _artistService = artistService;
            _dialogService = dialogService;
        }

        public void Initialize(int id)
        {
            _artist = _artistService.Get(id);

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

        public RelayCommand<IAlbum> OpenAlbumCommand => new RelayCommand<IAlbum>(_viewService.ShowView, x => x != null);

        public RelayCommand SaveCommand => new RelayCommand(Update);

        private void Update()
        {
            if(!_dialogService.ShowQuestion("Chcesz zapisać zmiany?"))
            {
                return;
            }

            _artistService.Update(_artist);

            _dialogService.ShowInfo("Zapisano.");
        }
    }
}
