using System;
using System.Data.Entity;

namespace InterpressExam.Data
{

    /// <summary>
    /// Creates a base class for different data access technologies.
    /// </summary>
    /// <typeparam name="TContextFactory">an DbContextFactory</typeparam>
    /// <typeparam name="TEntity">class that is an aggregate root</typeparam>
    public abstract class RepositoryBase<TContextFactory, TEntity> : IDisposable
        where TContextFactory : IDbContextFactory
        where TEntity : class
    {
        private DbContext _database;
        private readonly DbSet<TEntity> _dbset;

        protected RepositoryBase(IDbContextFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = Context.Set<TEntity>();
        }

        private IDbContextFactory DatabaseFactory
        {
            get;
            set;
        }

        protected DbContext Context
        {
            get { return _database ?? (_database = DatabaseFactory.Get()); }
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _database.Entry(entity).State = EntityState.Modified;
        }

        public TEntity GetById(object id)
        {
            return _dbset.Find(id);
        }

        #region dispose operations
        private bool _isDisposed;

        protected void DisposeCore()
        {
            if (_database != null)
                _database.Dispose();
        }

        ~RepositoryBase()
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
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }
        #endregion
    }
}
