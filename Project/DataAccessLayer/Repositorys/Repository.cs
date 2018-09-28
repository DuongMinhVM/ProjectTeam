using DataAccessLayer.IRepository;
using EntityLayer;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    /// <summary>
    /// Generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            this.context = context;

            dbSet = context.Set<T>();
        }

        /// <inheritdoc />
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        /// <inheritdoc />
        public T Get<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public T Get(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return FindBy(predicate).Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IQueryable<T> GetAll(int page, int pageCount)
        {
            int pageSize = (page - 1) * pageCount;

            return dbSet.Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include)
        {
            return dbSet.Include(include);
        }

        /// <inheritdoc />
        public IQueryable<T> GetAll(string include, string include2)
        {
            return dbSet.Include(include).Include(include2);
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        /// <inheritdoc />
        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}