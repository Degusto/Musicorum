using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IArtistService
    {
        void Add(IArtist artist);

        void Update(IArtist artist);

        void Delete(IArtist artist);

        IEnumerable<IArtist> Find(SearchCriteria searchCriteria);
    }
}
