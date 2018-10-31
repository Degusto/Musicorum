using System.Collections.Generic;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.BusinessLogic.Services
{
    internal sealed class TrackService : ITrackService
    {
        private readonly IRepository<ITrack> _trackRepository;

        internal TrackService(IRepository<ITrack> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public void Add(ITrack track)
        {
            _trackRepository.Save(track);
        }

        public void Delete(ITrack track)
        {
            if (!_trackRepository.Exists(track.Id))
            {
                throw new NotFoundException(track.Id, "track");
            }

            _trackRepository.Delete(track.Id);
        }

        public void Update(ITrack track)
        {
            if (!_trackRepository.Exists(track.Id))
            {
                throw new NotFoundException(track.Id, "track");
            }

            _trackRepository.Save(track);
        }

        public ITrack Get(int trackId) => _trackRepository.Get(trackId);

        public IEnumerable<ITrack> Find(SearchCriteria searchCriteria)
        {
            return _trackRepository.Find(IsMatch);

            bool IsMatch(ITrack track)
            {
                return track.Title.Contains(searchCriteria.Name)
                    && (searchCriteria.Genre == track.Album.Genre || searchCriteria.Genre == Core.Enums.Genre.All)
                    && (searchCriteria.IsDigital == null || track.Album.IsDigital == searchCriteria.IsDigital)
                    && (searchCriteria.IsForeign == null || track.Album.IsForeign == searchCriteria.IsForeign);
            }
        }
    }
}
