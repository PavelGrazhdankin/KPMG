using System;
using System.Data.Entity;
using System.Linq;

namespace TestAssignment.DB
{
    public class Repository<V> : IDisposable where V : DbMainContext
    {
        protected bool _disposed = false;
        protected DbMainContext _dbContext;

        public Repository(string connectionString, Action<object> creating, Action<object> created)
        {
            _dbContext = (V)Activator.CreateInstance(typeof(V), connectionString, creating, created);
        }

        ~Repository()
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
                    _dbContext.Dispose();
                }

                _disposed = true;
            }
        }

        public T Find<T>(Guid guid) where T : class
        {
            return _dbContext.Set<T>().Find(guid);
        }

        public IQueryable<T> FindAll<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public void InsertData<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
            }
            catch (Exception ex)
            {

            }
        }

        public void EraceData<T>(Guid entityId) where T : class
        {
            _dbContext.Set<T>().Remove(_dbContext.Set<T>().Find(entityId));
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool NewDatabase
        {
            get { return _dbContext.NewDatabase; }
        }
    }
}