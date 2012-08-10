using NHibernate;
using Sparks.Persistence;

namespace Sparks.FluentNHibernate.Persistence
{
    public interface INHibernateUnitOfWork : IUnitOfWork
    {
        ISession CurrentSession { get; }
        ITransaction Transaction { get; }
    }
}