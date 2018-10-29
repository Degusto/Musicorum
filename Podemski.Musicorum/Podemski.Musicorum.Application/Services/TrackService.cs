using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Application.SearchCriterias;
using Podemski.Musicorum.Application.ViewModels;

using Podemski.Musicorum.Common.Mapping;
using Podemski.Musicorum.Core.Attributes;
using Podemski.Musicorum.Core.Contracts.Repositories;
using Podemski.Musicorum.Core.Exceptions;
using Podemski.Musicorum.Core.Models;

namespace Podemski.Musicorum.Application.Services
{
    public interface ITrackService
    {
        void Add(TrackViewModel track);

        void Update(TrackViewModel track);

        void Delete(TrackViewModel track);

        IEnumerable<TrackShortInfo> Find(SearchCriteria searchCriteria);
    }

    internal sealed class TrackService : ITrackService
    {
        private readonly IMapper _mapper;
        private readonly ITrackRepository _trackRepository;

        internal TrackService(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        [Transaction]
        public void Add(TrackViewModel track)
        {
            _trackRepository.Save(_mapper.Map<TrackViewModel, Track>(track));
        }

        [Transaction]
        public void Delete(TrackViewModel track)
        {
            if (!_trackRepository.Exists(track.Id))
            {
                throw new NotFoundException(track.Id, "track");
            }

            _trackRepository.Delete(_mapper.Map<TrackViewModel, Track>(track));
        }

        [Transaction]
        public void Update(TrackViewModel track)
        {
            if (!_trackRepository.Exists(track.Id))
            {
                throw new NotFoundException(track.Id, "track");
            }

            _trackRepository.Save(_mapper.Map<TrackViewModel, Track>(track));
        }

        public IEnumerable<TrackShortInfo> Find(SearchCriteria searchCriteria)
        {
            return _trackRepository.Find(IsMatch).Select(_mapper.Map<Track, TrackShortInfo>);

            bool IsMatch(Track track)
            {
                return track.Title.Contains(searchCriteria.Name)
                    // TODO: Validation for Rap & Pop
                    && searchCriteria.Genre.HasFlag(track.Album.Genre)
                    && (searchCriteria.IsDigital == null || track.Album.IsDigital == searchCriteria.IsDigital)
                    && (searchCriteria.IsForeign == null || track.Album.IsForeign == searchCriteria.IsForeign);
            }
        }
    }
}
