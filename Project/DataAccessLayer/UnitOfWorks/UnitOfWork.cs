using DataAccessLayer.IRepositorys;
using DataAccessLayer.IUnitOfWorks;
using DataAccessLayer.Repositorys;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorks
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private DbContext _dbContext;

        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> _repositories;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public UnitOfWork(DbContext contextFactory)
        {
            _dbContext = contextFactory;
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public virtual IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            Type type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
#pragma warning disable CS0311 // The type 'TEntity' cannot be used as type parameter 'T' in the generic type or method 'Repository<T>'. There is no implicit reference conversion from 'TEntity' to 'System.IDisposable'.
                _repositories[type] = new Repository<TEntity>(_dbContext);
#pragma warning restore CS0311 // The type 'TEntity' cannot be used as type parameter 'T' in the generic type or method 'Repository<T>'. There is no implicit reference conversion from 'TEntity' to 'System.IDisposable'.
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> CommitAsync()
        {
            // Save changes with the default options
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(obj: this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}