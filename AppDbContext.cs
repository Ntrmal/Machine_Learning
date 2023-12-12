
using MongoDB.Driver;
using static VoltagePrediction.MLModel;
namespace VoltagePrediction
{


    public class AppDbContext
    {
        private readonly IMongoDatabase _database;

        public AppDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("simple_db");
        }

        public IMongoCollection<Trucksinfo> TruckData => _database.GetCollection<Trucksinfo>("TruckData");
    }
}