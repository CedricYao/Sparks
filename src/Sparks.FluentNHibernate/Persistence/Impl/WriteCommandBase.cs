namespace Sparks.FluentNHibernate.Persistence.Impl
{
    public abstract class WriteCommandBase<TEntity>
    {
        protected readonly INHibernateUnitOfWork _unitOfWork;

        protected WriteCommandBase(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save(TEntity Entity)
        {
            _unitOfWork.CurrentSession.SaveOrUpdate(Entity);
        }
    }
}