using System.Collections.Generic;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
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

        public void Add(IAlbum album)
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

        public void Update(IAlbum album)
        {
            if (!_albumRepository.Exists(album.Id))
            {
                throw new NotFoundException(album.Id, "album");
            }

            _albumRepository.Save(album);
        }

        public IEnumerable<IAlbum> Find(SearchCriteria searchCriteria)
        {
            return _albumRepository.Find(IsMatch);

            bool IsMatch(IAlbum album)
            {
                return album.Title.Contains(searchCriteria.Name)
                    && (album.Genre == searchCriteria.Genre || searchCriteria.Genre == Core.Enums.Genre.All)
                    && (searchCriteria.IsDigital == null || album.IsDigital == searchCriteria.IsDigital)
                    && (searchCriteria.IsForeign == null || album.IsForeign == searchCriteria.IsForeign);
            }
        }
    }
}
