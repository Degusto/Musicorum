using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface ISearchService
    {
        IEnumerable<IArtist> FindArtists(SearchCriteria searchCriteria);
        IEnumerable<IAlbum> FindAlbum(SearchCriteria searchCriteria);
        IEnumerable<ITrack> FindTrack(SearchCriteria searchCriteria);
    }
}
