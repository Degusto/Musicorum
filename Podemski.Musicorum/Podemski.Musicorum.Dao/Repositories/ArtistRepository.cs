using System;
using System.Collections.Generic;
using System.Linq;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class ArtistRepository : IRepository<IArtist>
    {
        private readonly IDataContext _context;

        internal ArtistRepository(IDataContext context)
        {
            _context = context;
        }

        public IArtist Get(int id) => _context.Artists.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Artists.Any(x => x.Id == id);

        public IEnumerable<IArtist> Find(Func<IArtist, bool> searchCriteria) => _context.Artists.Where(searchCriteria);

        public void Delete(int id)
        {
            _context.Artists.Remove(Get(id));
            _context.SaveChanges();
        }

        public void Save(IArtist item)
        {
            if (Exists(item.Id))
            {
                _context.Artists[_context.Artists.IndexOf(Get(item.Id))] = item;
            }
            else
            {
                _context.Artists.Add(item);
            }

            _context.SaveChanges();
        }
    }
}
