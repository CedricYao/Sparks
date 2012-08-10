namespace Sparks.Persistence
{
    public interface ICanDelete<TEntity>
    {
        void Delete(TEntity Entity);
    }
}