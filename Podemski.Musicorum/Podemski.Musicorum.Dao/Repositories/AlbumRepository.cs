using System;
using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class AlbumRepository : IRepository<IAlbum>
    {
        private readonly IDataContext _context;

        internal AlbumRepository(IDataContext context)
        {
            _context = context;
        }

        public IAlbum Get(int id) => _context.Albums.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Albums.Any(x => x.Id == id);

        public IEnumerable<IAlbum> Find(Func<IAlbum, bool> searchCriteria) => _context.Albums.Where(searchCriteria);

        public void Delete(int id)
        {
            _context.Albums.Remove(Get(id));
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
