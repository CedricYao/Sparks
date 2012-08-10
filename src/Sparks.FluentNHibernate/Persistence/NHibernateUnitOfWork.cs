using System;
using FluentNHibernate;
using NHibernate;

namespace Sparks.FluentNHibernate.Persistence
{
    public class NHibernateUnitOfWork : INHibernateUnitOfWork
    {
        private readonly ISessionSource _source;

        private bool isDisposed;

        private bool isInitialized;

        private ITransaction transaction;

        public NHibernateUnitOfWork(ISessionSource source)
        {
            _source = source;
        }

        #region INHibernateUnitOfWork Members

        public ITransaction Transaction
        {
            get { return transaction; }
        }

        public ISession CurrentSession { get; private set; }

        #endregion

        public void Commit()
        {
            should_not_currently_be_disposed();
            should_be_initialized_first();

            transaction.Commit();

            begin_new_transaction();
        }

        public void Dispose()
        {
            if (isDisposed || !isInitialized)
            {
                return;
            }

            transaction.Dispose();
            CurrentSession.Dispose();

            isDisposed = true;
        }

        public void Initialize()
        {
            should_not_currently_be_disposed();

            CurrentSession = _source.CreateSession();
            begin_new_transaction();

            isInitialized = true;
        }

        public void Rollback()
        {
            should_not_currently_be_disposed();
            should_be_initialized_first();

            transaction.Rollback();

            begin_new_transaction();
        }

        private void begin_new_transaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }

            transaction = CurrentSession.BeginTransaction();
        }

        private void should_be_initialized_first()
        {
            if (!isInitialized)
            {
                throw new InvalidOperationException(
                    "Must initialize (call Initialize()) on NHibernateUnitOfWork before commiting or rolling back");
            }
        }

        private void should_not_currently_be_disposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}