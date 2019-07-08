using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Models {
    public class User {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("Name")]
        [BsonRepresentation(BsonType.String)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("Password")]
        [BsonRepresentation(BsonType.String)]
        [JsonProperty("password")]
        public string Password { get; set; }

    }
}
