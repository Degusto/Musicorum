using System.Collections.Generic;

using Podemski.Musicorum.BusinessLogic.Exceptions;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Repositories;
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

        public void Save(ITrack track)
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

        public ITrack Get(int trackId)
        {
            if (!_trackRepository.Exists(trackId))
            {
                throw new NotFoundException(trackId, "track");
            }

            return _trackRepository.Get(trackId);
        }

        public IEnumerable<ITrack> Find(SearchCriteria searchCriteria)
        {
            return _trackRepository.Find(IsMatch);

            bool IsMatch(ITrack track)
            {
                return track.Title.Contains(searchCriteria.Name)
                    && (searchCriteria.Genre == track.Album.Genre || searchCriteria.Genre == Genre.All)
                    && (searchCriteria.AlbumVersion == AlbumVersion.None || (track.Album.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Digital) || (!track.Album.IsDigital && searchCriteria.AlbumVersion == AlbumVersion.Physical));
            }
        }
    }
}
