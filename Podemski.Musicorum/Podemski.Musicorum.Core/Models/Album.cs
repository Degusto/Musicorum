using System.Collections.Generic;
using Podemski.Musicorum.Common.Enums;

namespace Podemski.Musicorum.Core.Models
{
    public sealed class Album
    {
        public int Id { get; }

        public Artist Artist { get; }

        public string Title { get; }

        public Genre Genre { get; }

        public bool IsDigital { get; }

        public bool IsForeign { get; }

        public string Description { get; }

        public IList<Track> TrackList { get; }
    }
}