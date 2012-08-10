using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using Sparks.Core;
using Sparks.Persistence;
using Sparks.Persistence.Queries;

namespace Sparks.FluentNHibernate.Persistence
{
    public class GenericNHibernateRepository : IRepository
    {
        private readonly INHibernateUnitOfWork _unitOfWork;

        public GenericNHibernateRepository(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete<TEntity>(TEntity Entity) where TEntity : PersistentObject
        {
            _unitOfWork.CurrentSession.Delete(Entity);
        }

        public TEntity Get<TEntity>(Guid id) where TEntity : PersistentObject
        {
            return _unitOfWork.CurrentSession.Get<TEntity>(id);
        }

        public TEntity Load<TEntity>(Guid id) where TEntity : PersistentObject
        {
            return _unitOfWork.CurrentSession.Load<TEntity>(id);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : PersistentObject
        {
            return _unitOfWork.CurrentSession.Query<TEntity>();
        }

        public IQueryable<TEntity> Query<TEntity>(IDomainQuery<TEntity> whereQuery) where TEntity : PersistentObject
        {
            return _unitOfWork.CurrentSession.Query<TEntity>().Where(whereQuery.Expression);
        }

        public IList<TEntity> Query<TEntity>(ICriteriaQuery<TEntity> query) where TEntity : PersistentObject
        {
            return query.RetrieveCriteria(_unitOfWork.CurrentSession.CreateCriteria<TEntity>()).List<TEntity>();
        }

        public void Save<TEntity>(TEntity Entity) where TEntity : PersistentObject
        {
            _unitOfWork.CurrentSession.SaveOrUpdate(Entity);
        }
    }
}