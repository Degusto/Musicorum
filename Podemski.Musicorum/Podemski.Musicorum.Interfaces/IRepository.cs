using System;
using System.Collections.Generic;

namespace Podemski.Musicorum.Interfaces
{
    public interface IRepository<T>
    {
        void Save(T item);

        void Delete(int id);

        T Get(int id);

        bool Exists(int id);

        IEnumerable<T> Find(Func<T, bool> searchCriteria);
    }
}
