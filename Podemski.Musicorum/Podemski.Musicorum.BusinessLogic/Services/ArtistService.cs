using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.BusinessLogic.Services
{
    internal sealed class ArtistService : IArtistService
    {
        private readonly IRepository<IArtist> _artistRepository;

        internal ArtistService(IRepository<IArtist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public void Add(IArtist artist)
        {
            _artistRepository.Save(artist);
        }

        public void Delete(IArtist artist)
        {
            if (!_artistRepository.Exists(artist.Id))
            {
                throw new NotFoundException(artist.Id, "artist");
            }

            _artistRepository.Delete(artist.Id);
        }

        public void Update(IArtist artist)
        {
            if (!_artistRepository.Exists(artist.Id))
            {
                throw new NotFoundException(artist.Id, "artist");
            }

            _artistRepository.Save(artist);
        }

        public IArtist Get(int artistId) => _artistRepository.Get(artistId);

        public IEnumerable<IArtist> Find(SearchCriteria searchCriteria)
        {
            return _artistRepository.Find(IsMatch);

            bool IsMatch(IArtist artist)
            {
                return artist.Name.Contains(searchCriteria.Name)
                    && artist.Albums.Any(a => a.Genre == searchCriteria.Genre || searchCriteria.Genre == Core.Enums.Genre.All)
                    && (searchCriteria.AlbumVersion == AlbumVersion.None || artist.Albums.Any(a => (a.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Digital) || (!a.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Physical)));
            }
        }
    }
}