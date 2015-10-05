using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Model
{
    /// <summary>
    /// Represents a restaurant
    /// </summary>
    public class Entry : Entity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Location { get; set; }

        [BsonRequired]
        public System.Guid CategoryId { get; set; }
    }
}
