using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Restaurant.Model
{
    /// <summary>
    /// The base class for entitys
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entiy.
        /// </summary>
        [BsonId(IdGenerator = typeof(AscendingGuidGenerator))]
        public System.Guid Id { get; set; }
    }
}
