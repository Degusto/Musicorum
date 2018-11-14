using System;
using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Dao.Contexts;
using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class TrackRepository : ITrackRepository
    {
        private readonly Context _context;

        internal TrackRepository(Context context)
        {
            _context = context;
        }

        public ITrack Get(int id) => _context.Tracks.Single(x => x.Id == id);

        public bool Exists(int id) => _context.Tracks.Any(x => x.Id == id);

        public IEnumerable<ITrack> Find(Func<ITrack, bool> searchCriteria) => _context.Tracks.Where(searchCriteria);

        public void Delete(int id)
        {
            foreach (var album in _context.Albums.Where(a => a.TrackList.Any(t => t.Id == id)))
            {
                album.TrackList = album.TrackList.Where(t => t.Id != id);
            }

            _context.Tracks.Remove(_context.Tracks.Single(x => x.Id == id));

            _context.SaveChanges();
        }

        public void Save(ITrack item)
        {
            if (!Exists(item.Id))
            {
                _context.Tracks.Add((Track)item);

                ((Album)item.Album).TrackList = item.Album.TrackList.Concat(new List<Track> { (Track)item });

            }

            _context.SaveChanges();
        }
    }
}