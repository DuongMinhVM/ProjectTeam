using DataAccessLayer.IRepository;
using DataAccessLayer.IUnitOfWorks;
using DataAccessLayer.Repository;
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
        private DbContext dbContext;

        /// <summary>
        /// The repositories
        /// </summary>
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="contextFactory">The context factory.</param>
        public UnitOfWork(DbContext contextFactory)
        {
            dbContext = contextFactory;
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public virtual IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            Type type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(dbContext);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<int> CommitAsync()
        {
            // Save changes with the default options
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

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
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}