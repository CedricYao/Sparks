using FizzWare.NBuilder;
using NUnit.Framework;
using Sparks;
using Sparks.FluentNHibernate.Persistence;
using WebSample.Core.Model;

namespace WebSample.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class ZDataLoader : PersistenceFixtureBase
    {

        [Test, Explicit]
        public void LoadData()
        {
            var repository = new GenericNHibernateRepository(UnitOfWork as NHibernateUnitOfWork);

            var people = Builder<Person>.CreateListOfSize(5).Build();

            people.ForEach(repository.Save);
            UnitOfWork.Commit();
            Flush();
        }
    }

    // ReSharper restore InconsistentNaming 
}