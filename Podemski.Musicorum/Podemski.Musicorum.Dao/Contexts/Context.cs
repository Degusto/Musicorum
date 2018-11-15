using System.Collections.Generic;
using Podemski.Musicorum.Dao.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal abstract class Context
    {
        protected Context()
        {
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Tracks = new List<Track>();
        }

        public List<Artist> Artists { get; set; }

        public List<Album> Albums { get; set; }

        public List<Track> Tracks { get; set; }

        internal abstract void SaveChanges();

        internal abstract void LoadContext();
    }
}
