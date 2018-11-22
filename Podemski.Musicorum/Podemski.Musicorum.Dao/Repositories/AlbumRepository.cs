using System;
using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class AlbumRepository : IRepository<IAlbum>
    {
        private readonly Context _context;
        private readonly IRepository<ITrack> _trackRepository;

        internal AlbumRepository(Context context, IRepository<ITrack> trackRepository)
        {
            _context = context;
            _trackRepository = trackRepository;
        }

        public IAlbum Get(int id) => _context.Albums.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Albums.Any(x => x.Id == id);

        public IEnumerable<IAlbum> Find(Func<IAlbum, bool> searchCriteria) => _context.Albums.Where(searchCriteria);

        public void Delete(int id)
        {
            var album = (Album)Get(id);

            foreach (var artist in _context.Artists.Where(a => a.Albums.Any(x => x.Id == id)))
            {
                artist.Albums = artist.Albums.Where(a => a.Id != id);
            }

            foreach (var track in album.Tracks.ToList())
            {
                _trackRepository.Delete(track.Id);
            }

            _context.Albums.Remove(album);

            _context.SaveChanges();
        }

        public void Save(IAlbum item)
        {
            if (!Exists(item.Id))
            {
                _context.Albums.Add((Album)item);

                ((Artist)item.Artist).Albums = item.Artist.Albums.Concat(new List<Album> { (Album)item });
            }

            _context.SaveChanges();
        }
    }
}
