using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Application.Attributes;
using Podemski.Musicorum.Application.ViewModels;
using Podemski.Musicorum.Common.Mapping;
using Podemski.Musicorum.Core.Contracts.Repositories;
using Podemski.Musicorum.Core.Exceptions;
using Podemski.Musicorum.Core.Models;

namespace Podemski.Musicorum.Application.Services
{
    public interface IArtistService
    {
        void Add(ArtistViewModel artist);

        void Update(ArtistViewModel artist);

        void Delete(ArtistViewModel artist);

        IEnumerable<ArtistViewModel> FindByName(string name);
    }

    internal sealed class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        internal ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        [Transaction]
        public void Add(ArtistViewModel artist)
        {
            _artistRepository.Save(_mapper.Map<ArtistViewModel, Artist>(artist));
        }

        [Transaction]
        public void Delete(ArtistViewModel artist)
        {
            if (!_artistRepository.Exists(artist.Id))
            {
                throw new NotFoundException(artist.Id, "artist");
            }

            _artistRepository.Delete(_mapper.Map<ArtistViewModel, Artist>(artist));
        }

        [Transaction]
        public void Update(ArtistViewModel artist)
        {
            if (!_artistRepository.Exists(artist.Id))
            {
                throw new NotFoundException(artist.Id, "artist");
            }

            _artistRepository.Save(_mapper.Map<ArtistViewModel, Artist>(artist));
        }

        public IEnumerable<ArtistViewModel> FindByName(string name)
        {
            return _artistRepository.Find(x => x.Name.Contains(name)).Select(_mapper.Map<Artist, ArtistViewModel>);
        }
    }
}