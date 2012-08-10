using System;
using System.Collections.Generic;
using System.Linq;
using Sparks.Core;
using Sparks.Persistence.Queries;

namespace Sparks.Persistence
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity Entity) where TEntity : PersistentObject;
        void Delete<TEntity>(TEntity Entity) where TEntity : PersistentObject;
        TEntity Load<TEntity>(Guid id) where TEntity : PersistentObject;
        TEntity Get<TEntity>(Guid id) where TEntity : PersistentObject;
        IQueryable<TEntity> Query<TEntity>() where TEntity : PersistentObject;
        IQueryable<TEntity> Query<TEntity>(IDomainQuery<TEntity> whereQuery) where TEntity : PersistentObject;
        IList<TEntity> Query<TEntity>(ICriteriaQuery<TEntity> query) where TEntity : PersistentObject;
    }
}