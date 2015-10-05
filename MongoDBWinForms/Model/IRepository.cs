using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Restaurant.Model
{
    /// <summary>
    /// Interface of a MongoDB repository
    /// </summary>
    /// <typeparam name="T">The entity type that is used as main type</typeparam>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="id">An unique identifier of the entity</param>
        void Delete(Guid id);

        /// <summary>
        /// Finds an entity with the given id
        /// </summary>
        /// <param name="id">An unique identifier of the entity</param>
        /// <returns></returns>
        Task<T> FindbyId(Guid id);

        /// <summary>
        /// Returns all entities of the repository
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAll();
    }
}
