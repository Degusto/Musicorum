using System;

namespace Podemski.Musicorum.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();

        void Commit();

        void Rollback();
    }
}
