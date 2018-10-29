using System;
using System.Collections.Generic;

namespace Podemski.Musicorum.Core.Contracts.Repositories
{
    public interface IRepository<T>
    {
        void Save(T item);

        void Delete(T item);

        T Get(int id);

        bool Exists(int id);

        IEnumerable<T> Find(Func<T, bool> searchCriteria);
    }
}
