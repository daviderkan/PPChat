using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("Author")]
        [BsonRepresentation(BsonType.String)]
        [JsonProperty("author")]
        public string Author { get; set; }

        [BsonElement("Content")]
        [BsonRepresentation(BsonType.String)]
        [JsonProperty("content")]
        public string Content { get; set; }

        [BsonElement("CreationTime")]
        [BsonRepresentation(BsonType.DateTime)]
        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }
    }
}
