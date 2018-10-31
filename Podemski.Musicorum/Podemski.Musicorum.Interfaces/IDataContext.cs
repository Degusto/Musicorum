using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces
{
    public interface IDataContext
    {
        IList<IArtist> Artists { get; }

        IList<IAlbum> Albums { get; }

        IList<ITrack> Tracks { get; }

        void SaveChanges();
    }
}
