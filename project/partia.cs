using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace project
{
    class partia
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("arr")]
        public BsonArray MASSIV { get; set; }

        public partia(string title, BsonArray arr)
        {
            Title = title;
            MASSIV = arr;
        }
    }
}
