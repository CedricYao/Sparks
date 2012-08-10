using FluentNHibernate;

namespace Sparks.FluentNHibernate.Configuration
{
    public interface ISessionSourceProvider
    {
        ISessionSource GetSessionSource();
    }
}