using DataAccessLayer.IRepositorys;
using EntityLayer;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositorys
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            _context = context;

            _dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        /// <inheritdoc />
        public async Task<T> Get<TKey>(TKey id)
        {
            T result = await _dbSet.FindAsync(id);
            return result;
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task<T> Get(params object[] keyValues)
        {
            T result = await _dbSet.FindAsync(keyValues);
            return result;
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            System.Collections.Generic.List<T> result = await _dbSet.Where(predicate).ToListAsync<T>();
            return result as IQueryable<T>;
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            System.Collections.Generic.List<T> result = await _dbSet.Where(predicate).Include(include).ToListAsync();
            return result as IQueryable<T>;
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> GetAll()
        {
            System.Collections.Generic.List<T> result = await _dbSet.ToListAsync();
            return result as IQueryable<T>;
        }

        public async Task<IQueryable<T>> GetAll(int page, int pageCount)
        {
            int pageSize = (page - 1) * pageCount;
            System.Collections.Generic.List<T> result = await _dbSet.Skip(pageSize).Take(pageCount).ToListAsync();
            return result as IQueryable<T>;
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> GetAll(string include)
        {
            System.Collections.Generic.List<T> result = await _dbSet.Include(include).ToListAsync<T>();
            return result as IQueryable<T>;
        }

        /// <inheritdoc />
        public async Task<IQueryable<T>> GetAll(string include, string include2)
        {
            System.Collections.Generic.List<T> result = await _dbSet.Include(include).Include(include2).ToListAsync();
            return result as IQueryable<T>;
        }

        /// <inheritdoc />
        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        /// <inheritdoc />
        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}