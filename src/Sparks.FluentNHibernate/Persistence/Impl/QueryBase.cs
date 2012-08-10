using System.Linq;
using NHibernate.Linq;

namespace Sparks.FluentNHibernate.Persistence.Impl
{
    public abstract class QueryBase<TEntity, TId>
    {
        protected readonly INHibernateUnitOfWork _unitOfWork;

        protected QueryBase(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TEntity Get(TId id)
        {
            return _unitOfWork.CurrentSession.Get<TEntity>(id);
        }

        public TEntity Load(TId id)
        {
            return _unitOfWork.CurrentSession.Load<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _unitOfWork.CurrentSession.Query<TEntity>();
        }
    }
}