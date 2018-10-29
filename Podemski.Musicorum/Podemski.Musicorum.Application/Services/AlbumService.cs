using Podemski.Musicorum.Application.Attributes;
using Podemski.Musicorum.Application.ViewModels;

using Podemski.Musicorum.Common.Mapping;

using Podemski.Musicorum.Core.Contracts.Repositories;
using Podemski.Musicorum.Core.Exceptions;
using Podemski.Musicorum.Core.Models;

namespace Podemski.Musicorum.Application.Services
{
    public interface IAlbumService
    {
        void Add(AlbumViewModel album);

        void Update(AlbumViewModel album);

        void Delete(AlbumViewModel album);
    }

    internal sealed class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        internal AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        [Transaction]
        public void Add(AlbumViewModel album)
        {
            _albumRepository.Save(_mapper.Map<AlbumViewModel, Album>(album));
        }

        [Transaction]
        public void Delete(AlbumViewModel album)
        {
            if (!_albumRepository.Exists(album.Id))
            {
                throw new NotFoundException(album.Id, "album");
            }

            _albumRepository.Delete(_mapper.Map<AlbumViewModel, Album>(album));
        }

        [Transaction]
        public void Update(AlbumViewModel album)
        {
            if (!_albumRepository.Exists(album.Id))
            {
                throw new NotFoundException(album.Id, "album");
            }

            _albumRepository.Save(_mapper.Map<AlbumViewModel, Album>(album));
        }
    }
}
