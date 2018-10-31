using System.Collections.Generic;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal abstract class BaseContext : IDataContext
    {
        private bool _isLoaded = false;

        private IList<IArtist> _artists;
        private IList<IAlbum> _albums;
        private IList<ITrack> _tracks;

        public IList<IArtist> Artists
        {
            get
            {
                Load();

                return _artists;
            }
            set => _artists = value;
        }

        public IList<IAlbum> Albums
        {
            get
            {
                Load();

                return _albums;
            }
            set => _albums = value;
        }

        public IList<ITrack> Tracks
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
