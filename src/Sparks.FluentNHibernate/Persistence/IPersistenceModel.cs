using FluentNHibernate;

namespace Sparks.FluentNHibernate.Persistence
{
    public interface IPersistenceModel
    {
        PersistenceModel GetPersistenceModel();
    }
}