using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IAlbumService
    {
        void Update(IAlbum album);

        void Delete(IAlbum album);

        IAlbum Get(int albumId);

        IEnumerable<IAlbum> Find(SearchCriteria searchCriteria);
    }
}