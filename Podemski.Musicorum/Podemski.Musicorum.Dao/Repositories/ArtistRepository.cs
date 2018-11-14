using System;
using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Dao.Contexts;
using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class ArtistRepository : IArtistRepository
    {
        private readonly Context _context;
        private readonly IAlbumRepository _albumRepository;

        internal ArtistRepository(Context context, IAlbumRepository albumRepository)
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

            foreach (var album in artist.Albums)
            {
                _albumRepository.Delete(album.Id);
            }

            _context.Artists.Remove((Artist)artist);

            _context.SaveChanges();
        }

        public void Save(IArtist item)
        {
            if (!Exists(item.Id))
            {
                _context.Artists.Add((Artist)item);
            }

            _context.SaveChanges();
        }

        public void AddAlbum(IArtist artist, IAlbum album)
        {
            var artistToAdd = (Artist)Get(artist.Id);

            _albumRepository.Save(album);

            artistToAdd.Albums = artist.Albums.Concat(new List<IAlbum> { album });

            _context.SaveChanges();
        }
    }
}