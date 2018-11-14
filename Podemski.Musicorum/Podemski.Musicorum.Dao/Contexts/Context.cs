using System.Collections.Generic;

using Podemski.Musicorum.Dao.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal abstract class Context
    {
        private bool _isLoaded;

        private List<Artist> _artists;
        private List<Album> _albums;
        private List<Track> _tracks;

        public List<Artist> Artists
        {
            get
            {
                Load();

                return _artists;
            }
            set => _artists = value;
        }

        public List<Album> Albums
        {
            get
            {
                Load();

                return _albums;
            }
            set => _albums = value;
        }

        public List<Track> Tracks
        {
            get
            {
                Load();

                return _tracks;
            }
            set => _tracks = value;
        }

        public abstract void SaveChanges();

        protected abstract void LoadContext();

        private void Load()
        {
            if (!_isLoaded)
            {
                LoadContext();

                _isLoaded = true;
            }
        }
    }
}
