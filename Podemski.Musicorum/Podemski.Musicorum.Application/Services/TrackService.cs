using System.Collections.Generic;
using System.Linq;
using Podemski.Musicorum.Application.ViewModels;

using Podemski.Musicorum.Common.Mapping;
using Podemski.Musicorum.Core.Attributes;
using Podemski.Musicorum.Core.Contracts.Repositories;
using Podemski.Musicorum.Core.Exceptions;
using Podemski.Musicorum.Core.Models;
using Podemski.Musicorum.Core.Services;

namespace Podemski.Musicorum.Application.Services
{
    public interface ITrackService
    {
        void Add(TrackViewModel track);

        void Update(TrackViewModel track);

        void Delete(TrackViewModel track);

        IEnumerable<TrackShortInfo> FindByName(string name);

        void Play(TrackViewModel track);

        void Pause();

        void Resume();
    }

    internal sealed class TrackService : ITrackService
    {
        private readonly IMapper _mapper;
        private readonly IPlayer _player;
        private readonly ITrackRepository _trackRepository;

        internal TrackService(ITrackRepository trackRepository, IPlayer player, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _player = player;
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

        public IEnumerable<TrackShortInfo> FindByName(string name)
        {
            return _trackRepository.Find(x => x.Title.Contains(name)).Select(_mapper.Map<Track, TrackShortInfo>);
        }

        public void Play(TrackViewModel track)
        {
            throw new System.NotImplementedException();
        }

        public void Pause() => _player.Pause();

        public void Resume() => _player.Resume();
    }
}
