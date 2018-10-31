using System;
using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class TrackRepository : IRepository<ITrack>
    {
        private readonly IDataContext _context;

        internal TrackRepository(IDataContext context)
        {
            _context = context;
        }

        public ITrack Get(int id) => _context.Tracks.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Tracks.Any(x => x.Id == id);

        public IEnumerable<ITrack> Find(Func<ITrack, bool> searchCriteria) => _context.Tracks.Where(searchCriteria);

        public void Delete(int id)
        {
            _context.Tracks.Remove(Get(id));
            _context.SaveChanges();
        }

        public void Save(ITrack item)
        {
            if (Exists(item.Id))
            {
                _context.Tracks[_context.Tracks.IndexOf(Get(item.Id))] = item;
            }
            else
            {
                _context.Tracks.Add(item);
            }

            _context.SaveChanges();
        }
    }
}