using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IArtistService
    {
        void Save(IArtist artist);

        void Delete(IArtist artist);

        IArtist Get(int id);

        IEnumerable<IArtist> Find(SearchCriteria searchCriteria);
    }
}
