namespace Sparks.Persistence
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Initialize();
        void Commit();
        void Rollback();
    }
}