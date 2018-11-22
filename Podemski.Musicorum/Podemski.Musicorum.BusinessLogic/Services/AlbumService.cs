using System.Collections.Generic;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.BusinessLogic.Services
{
    internal sealed class AlbumService : IAlbumService
    {
        private readonly IRepository<IAlbum> _albumRepository;

        internal AlbumService(IRepository<IAlbum> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void Save(IAlbum album)
        {
            _albumRepository.Save(album);
        }

        public void Delete(IAlbum album)
        {
            if (!_albumRepository.Exists(album.Id))
            {
                throw new NotFoundException(album.Id, "album");
            }

            _albumRepository.Delete(album.Id);
        }

        public IAlbum Get(int albumId)
        {
            if (!_albumRepository.Exists(albumId))
            {
                throw new NotFoundException(albumId, "album");
            }

            return _albumRepository.Get(albumId);
        }

        public IEnumerable<IAlbum> Find(SearchCriteria searchCriteria)
        {
            return _albumRepository.Find(IsMatch);

            bool IsMatch(IAlbum album)
            {
                return album.Title.Contains(searchCriteria.Name)
                    && (album.Genre == searchCriteria.Genre || searchCriteria.Genre == Genre.All)
                    && (searchCriteria.AlbumVersion == AlbumVersion.None || (album.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Digital) || (!album.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Physical));
            }
        }
    }
}
