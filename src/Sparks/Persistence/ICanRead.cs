namespace Sparks.Persistence
{
    using System.Linq;

    public interface ICanRead<TEntity, TId>
    {
        TEntity Get(TId id);
        TEntity Load(TId id);
        IQueryable<TEntity> Query();
    }
}