using System;
using System.Collections.Generic;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Repositories
{
    internal sealed class AlbumRepository : IRepository<IAlbum>
    {
        public void Delete(int id) => throw new NotImplementedException();
        public bool Exists(int id) => throw new NotImplementedException();
        public IEnumerable<IAlbum> Find(Func<IAlbum, bool> searchCriteria) => throw new NotImplementedException();
        public IAlbum Get(int id) => throw new NotImplementedException();
        public void Save(IAlbum item) => throw new NotImplementedException();
    }
}
