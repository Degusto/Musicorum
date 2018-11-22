using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;
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

        public void Save(IArtist artist)
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

        public IArtist Get(int artistId)
        {
            if (!_artistRepository.Exists(artistId))
            {
                throw new NotFoundException(artistId, "artist");
            }

            return _artistRepository.Get(artistId);
        }

        public IEnumerable<IArtist> Find(SearchCriteria searchCriteria)
        {
            return _artistRepository.Find(IsMatch);

            bool IsMatch(IArtist artist)
            {
                return artist.Name.Contains(searchCriteria.Name)
                    && (searchCriteria.Genre == Genre.All || artist.Albums.Any(a => a.Genre == searchCriteria.Genre))
                    && (searchCriteria.AlbumVersion == AlbumVersion.None || artist.Albums.Any(a => (a.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Digital) || (!a.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Physical)));
            }
        }
    }
}