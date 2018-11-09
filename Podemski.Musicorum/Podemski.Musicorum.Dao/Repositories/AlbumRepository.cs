using System;
using System.Collections.Generic;
using System.Linq;
using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class AlbumRepository : IRepository<IAlbum>
    {
        private readonly IDataContext _context;
        private readonly IRepository<ITrack> _trackRepository;

        internal AlbumRepository(IDataContext context, IRepository<ITrack> trackRepository)
        {
            _context = context;
            _trackRepository = trackRepository;
        }

        public IAlbum Get(int id) => _context.Albums.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Albums.Any(x => x.Id == id);

        public IEnumerable<IAlbum> Find(Func<IAlbum, bool> searchCriteria) => _context.Albums.Where(searchCriteria);

        public void Delete(int id)
        {
            var album = Get(id);

            foreach (var artist in _context.Artists.Where(a => a.Albums.Any(x => x.Id == id)))
            {
                artist.Albums = artist.Albums.Where(a => a.Id != id);
            }

            foreach (var track in album.TrackList)
            {
                _trackRepository.Delete(track.Id);
            }

            _context.Albums.Remove(album);

            _context.SaveChanges();
        }

        public void Save(IAlbum item)
        {
            if (Exists(item.Id))
            {
                _context.Albums[_context.Albums.IndexOf(Get(item.Id))] = item;
            }
            else
            {
                _context.Albums.Add(item);
            }

            _context.SaveChanges();
        }
    }
}
