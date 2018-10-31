using System.Collections.Generic;

using Podemski.Musicorum.Core.Enums;

namespace Podemski.Musicorum.Interfaces.Entities
{
    public interface IAlbum : IEntity
    {
        IArtist Artist { get; }

        string Title { get; set; }

        Genre Genre { get; set; }

        bool IsDigital { get; set; }

        bool IsForeign { get; set; }

        string Description { get; set; }

        IEnumerable<ITrack> TrackList { get; set; }
    }
}
