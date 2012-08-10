namespace Sparks.FluentNHibernate.Persistence.Impl
{
    public abstract class DeleteCommandBase<TEntity>
    {
        protected readonly INHibernateUnitOfWork _unitOfWork;

        protected DeleteCommandBase(INHibernateUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(TEntity Entity)
        {
            _unitOfWork.CurrentSession.Delete(Entity);
        }
    }
}