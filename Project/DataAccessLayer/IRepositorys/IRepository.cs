﻿using EntityLayer;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositorys
{
    /// <summary>
    /// Interface for generic repository, contains CRUD operation of EF entity
    /// </summary>
    /// <typeparam name="T">EF entity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        Task<T> Get<TKey>(TKey id);

        /// <summary>
        /// Gets the specified identifier. Asynchronous version.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Task Entity</returns>
        Task<T> GetAsync<TKey>(TKey id);

        /// <summary>
        /// Gets an entity by the keys specified in <paramref name="keyValues"/>
        /// </summary>
        /// <param name="keyValues">Composite Primary Key Identifiers</param>
        /// <returns>The requested Entity</returns>
        Task<T> Get(params object[] keyValues);

        /// <summary>
        /// Generic find by predicate
        /// </summary>
        /// <param name="predicate">Query predicate</param>
        /// <returns>Entity</returns>
        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Generic find by predicate and option to include child entity
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="include">The include sub-entity.</param>
        /// <returns>Queryable</returns>
        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate, string include);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of entities</returns>
        Task<IQueryable<T>> GetAll();

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        Task<IQueryable<T>> GetAll(int page, int pageCount);

        /// <summary>
        /// Gets all and offers to include a related table
        /// </summary>
        /// <param name="include">Te sub.entity to include</param>
        /// <returns>List of entities</returns>
        Task<IQueryable<T>> GetAll(string include);

        /// <summary>
        /// Gets all and offers to include 2 related tables
        /// </summary>
        /// <param name="include">The sub.entity to include</param>
        /// <param name="include2">The second sub.entity to include</param>
        /// <returns>List of entities</returns>
        Task<IQueryable<T>> GetAll(string include, string include2);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's T</returns>
        T Add(T entity);

        /// <summary>
        /// Deletes the specified <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>The Entity's T</returns>
        T Delete(T entity);

        /// <summary>
        /// Checks whether a entity matching the <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">The predicate to filter on</param>
        /// <returns>Whether an entity matching the <paramref name="predicate"/> exists</returns>
        Task<bool> Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's void</returns>
        void Update(T entity);
    }
}