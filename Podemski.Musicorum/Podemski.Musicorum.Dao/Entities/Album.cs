using System.Collections.Generic;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Album : IAlbum
    {
        public int Id { get; internal set; }

        public IArtist Artist { get; internal set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public bool IsDigital { get; set; }

        public string Description { get; set; }

        public IEnumerable<ITrack> TrackList { get; set; }

        public override string ToString() => $"{Artist.Name} - {Title}";
    }
}