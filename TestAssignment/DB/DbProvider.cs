using System;
using System.Data.Entity;
using System.Data.SqlClient;
using TestAssignment.Models;

namespace TestAssignment.DB
{
    public class DbProvider<T> : IDisposable where T : DbMainContext
    {
        protected bool _disposed = false;

        protected Repository<T> _repository { get; private set; }

        public DbProvider()
            :this(null, null)
        {
        }

        public DbProvider(Action<object> creating, Action<object> created)
        {
            _repository = RepositoryFactory<T>.CreateRepository(creating, created);
            ConnectionFailed = _repository == null;
        }

        ~DbProvider()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repository?.Dispose();
                }

                _disposed = true;
            }
        }

        public bool ConnectionFailed { get; private set; }

        public void AddRecord(TaxFigure record)
        {
            _repository.InsertData(record);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}