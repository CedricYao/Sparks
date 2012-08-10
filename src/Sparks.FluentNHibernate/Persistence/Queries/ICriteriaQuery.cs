using NHibernate;
using Sparks.Core;

namespace Sparks.Persistence.Queries
{
    public interface ICriteriaQuery<TEntity> where TEntity : PersistentObject
    {
        ICriteria RetrieveCriteria(ICriteria criteria);
    }
}