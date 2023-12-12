using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;
namespace VoltagePrediction
{

    public class Trucksinfo
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        public string sku { get; set; }
        public int tenantId { get; set; }

        public string identifier { get; set; }
        public string serialNumber { get; set; }  

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset originTime { get; set; }     

        public BsonDocument payload { get; set; }
    }
}


