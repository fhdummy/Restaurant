using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Restaurant.Model
{
    /// <summary>
    /// Represents the categories
    /// </summary>
    public class Category : Entity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [BsonRequired]
        public string Name { get; set; }

        public Category (string name)
        {
            this.Name = name;
        }
    }
}
