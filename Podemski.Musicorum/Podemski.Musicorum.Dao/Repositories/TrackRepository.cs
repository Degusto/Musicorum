using System;
using System.Collections.Generic;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class TrackRepository : IRepository<ITrack>
    {
        public void Delete(int id) => throw new NotImplementedException();
        public bool Exists(int id) => throw new NotImplementedException();
        public IEnumerable<ITrack> Find(Func<ITrack, bool> searchCriteria) => throw new NotImplementedException();
        public ITrack Get(int id) => throw new NotImplementedException();
        public void Save(ITrack item) => throw new NotImplementedException();
    }
}
