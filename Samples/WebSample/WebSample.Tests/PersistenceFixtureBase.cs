using Sparks.FluentNHibernate.Persistence;
using System;
using FluentNHibernate;
using NHibernate;
using NUnit.Framework;
using Sparks.Persistence;

namespace WebSample.Tests
{
    public abstract class PersistenceFixtureBase
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        public static ISessionSource SessionSource { get; set; }
        protected ISession CurrentSession
        {
            get { return ((NHibernateUnitOfWork)UnitOfWork).CurrentSession; }
        }

        [SetUp]
        public void SetupContext()
        {
            Before_each_test();
        }

        [TearDown]
        public void TearDownContext()
        {
            After_each_test();
        }


        protected virtual void After_each_test()
        {
            UnitOfWork.Rollback();
            UnitOfWork.Dispose();
        }

        protected virtual void Before_each_test()
        {
            try
            {
                UnitOfWork = new NHibernateUnitOfWork(SessionSource);
                UnitOfWork.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Following Error was detected:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Flushes the current session to the database
        /// </summary>
        protected virtual void Flush()
        {
            ((NHibernateUnitOfWork)UnitOfWork).CurrentSession.Flush();
        }


        /// <summary>
        /// Evict domain entity objects from the cache
        /// </summary>
        protected virtual void Evict(object entity)
        {
            ((NHibernateUnitOfWork)UnitOfWork).CurrentSession.Evict(entity);
        }

        /// <summary>
        /// Evicts all objects from session
        /// </summary>
        protected virtual void Clear()
        {
            ((NHibernateUnitOfWork)UnitOfWork).CurrentSession.Clear();
        }
    }
}