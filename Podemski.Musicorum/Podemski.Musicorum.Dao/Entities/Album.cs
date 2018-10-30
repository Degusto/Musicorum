using System.Collections.Generic;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Album : IAlbum
    {
        public int Id { get; set; }

        public IArtist Artist { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public bool IsDigital { get; set; }

        public bool IsForeign { get; set; }

        public string Description { get; set; }

        public IEnumerable<ITrack> TrackList { get; set; }
    }
}