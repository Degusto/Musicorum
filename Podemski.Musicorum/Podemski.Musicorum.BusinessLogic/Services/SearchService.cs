using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.BusinessLogic.Services
{
    internal sealed class SearchService : ISearchService
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;

        internal SearchService(IArtistService artistService, IAlbumService albumService, ITrackService trackService)
        {
            _artistService = artistService;
            _albumService = albumService;
            _trackService = trackService;
        }

        public IEnumerable<IArtist> FindArtists(SearchCriteria searchCriteria) => _artistService.Find(searchCriteria);

        public IEnumerable<IAlbum> FindAlbum(SearchCriteria searchCriteria) => _albumService.Find(searchCriteria);

        public IEnumerable<ITrack> FindTrack(SearchCriteria searchCriteria) => _trackService.Find(searchCriteria);
    }
}
