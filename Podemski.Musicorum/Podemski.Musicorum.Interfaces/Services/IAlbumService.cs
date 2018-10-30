using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IAlbumService
    {
        void Add(IAlbum album);

        void Update(IAlbum album);

        void Delete(IAlbum album);

        IEnumerable<IAlbum> Find(SearchCriteria searchCriteria);
    }
}
