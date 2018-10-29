﻿using System.Collections.Generic;
using Podemski.Musicorum.Common.Enums;

namespace Podemski.Musicorum.Application.ViewModels
{
    public sealed class AlbumViewModel
    {
        internal AlbumViewModel(int id)
        {
            Id = id;
        }

        internal int Id { get; }

        public int ArtistId { get; set; }

        public string ArtistName { get; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public IEnumerable<TrackViewModel> TrackList { get; set; }
    }
}
