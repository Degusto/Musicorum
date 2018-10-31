using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal abstract class BaseContext : IDataContext
    {
        public IList<IArtist> Artists { get; protected set; }

        public IList<IAlbum> Albums { get; protected set; }

        public IList<ITrack> Tracks { get; protected set; }

        protected abstract void SaveContext();

        protected abstract void LoadContext();

        public void SaveChanges()
        {
            foreach (var artist in Artists.Cast<Artist>())
            {
                if (artist.Id == 0)
                {
                    artist.Id = Artists.Max(x => x.Id);
                }
            }

            foreach (var album in Albums.Cast<Album>())
            {
                if (album.Id == 0)
                {
                    album.Id = Albums.Max(x => x.Id);
                }
            }

            foreach (var tracks in Tracks.Cast<Track>())
            {
                if (tracks.Id == 0)
                {
                    tracks.Id = Tracks.Max(x => x.Id);
                }
            }

            SaveContext();
        }
    }
}
