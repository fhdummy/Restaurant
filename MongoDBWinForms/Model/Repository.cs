using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;

namespace Restaurant.Model
{
    /// <summary>
    /// Implements a MongoDB repository
    /// </summary>
    /// <remarks>
    /// The MongoDB Server have to run on the local system
    /// </remarks>
    /// <typeparam name="T">The entity type that is used as main type</typeparam>
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        /// <summary>
        /// c'tor
        /// </summary>
        /// <param name="databaseName">The name of the database</param>
        /// <param name="collectionName"></param>
        public Repository(string databaseName, string collectionName)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(databaseName);
            _collectionName = collectionName;
        }

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async void Add(T entity)
        {
            var posts = _database.GetCollection<T>(_collectionName);
            await posts.InsertOneAsync(entity);
        }

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async void Update(T entity)
        {
            var posts = _database.GetCollection<T>(_collectionName);
            var filter = Builders<T>.Filter.Eq(T => T.Id, entity.Id);
            await posts.ReplaceOneAsync(filter, entity);
        }

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="id">An unique identifier of the entity</param>
        public async void Delete(Guid id)
        {
            var posts = _database.GetCollection<T>(_collectionName);
            var filter = Builders<T>.Filter.Eq(T => T.Id, id);
            await posts.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Finds an entity with the given id
        /// </summary>
        /// <param name="id">An unique identifier of the entity</param>
        /// <returns></returns>
        public async Task<T> FindbyId(Guid id)
        {
            var posts = _database.GetCollection<T>(_collectionName);
            var filter = Builders<T>.Filter.Eq(T => T.Id, id);
            using (var cursor = await posts.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        return document;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns all entities of the repository
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> GetAll()
        {
            var posts = _database.GetCollection<T>(_collectionName);
            var filter = new BsonDocument();
            using (var cursor = await posts.FindAsync(filter))
            {
                return await cursor.ToListAsync();
            }
        }
    }
}
