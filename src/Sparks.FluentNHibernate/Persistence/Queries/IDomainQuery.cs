using Sparks.Core;

namespace Sparks.Persistence.Queries
{
    using System;
    using System.Linq.Expressions;

    public interface IDomainQuery<TEntity> where TEntity : PersistentObject
    {
        Expression<Func<TEntity, bool>> Expression { get; }
    }
}