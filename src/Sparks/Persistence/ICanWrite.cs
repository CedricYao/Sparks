namespace Sparks.Persistence
{
    public interface ICanWrite<TEntity>
    {
        void Save(TEntity Entity);
    }
}