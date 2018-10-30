using System;
using System.Collections.Generic;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class ArtistRepository : IRepository<IArtist>
    {
        public void Delete(int id) => throw new NotImplementedException();
        public bool Exists(int id) => throw new NotImplementedException();
        public IEnumerable<IArtist> Find(Func<IArtist, bool> searchCriteria) => throw new NotImplementedException();
        public IArtist Get(int id) => throw new NotImplementedException();
        public void Save(IArtist item) => throw new NotImplementedException();
    }
}
