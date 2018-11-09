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
        private readonly IRepository<IAlbum> _albumRepository;

        internal ArtistRepository(IDataContext context, IRepository<IAlbum> albumRepository)
        {
            _context = context;
            _albumRepository = albumRepository;
        }

        public IArtist Get(int id) => _context.Artists.Single(x => x.Id == id);


        public bool Exists(int id) => _context.Artists.Any(x => x.Id == id);

        public IEnumerable<IArtist> Find(Func<IArtist, bool> searchCriteria) => _context.Artists.Where(searchCriteria);

        public void Delete(int id)
        {
            var artist = Get(id);

            foreach(var album in artist.Albums)
            {
                _albumRepository.Delete(album.Id);
            }

            _context.Artists.Remove(artist);

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
