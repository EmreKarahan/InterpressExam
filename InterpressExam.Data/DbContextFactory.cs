using System;
using System.Data.Entity;

namespace InterpressExam.Data
{
    public class DbContextFactory<TContext> : IDbContextFactory
        where TContext : DbContext
    {
        private readonly DbContext _database;

        public DbContextFactory(TContext database)
        {
            _database = database;
        }

        public DbContext Get()
        {
            return _database;
        }

        protected void DisposeCore()
        {
            if (_database != null)
                _database.Dispose();
        }

        private bool _isDisposed;

        ~DbContextFactory()
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
    }
}