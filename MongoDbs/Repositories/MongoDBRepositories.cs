using MongoDB.Driver;

namespace MongoDbs.Repositories
{
    public class MongoDBRepositories
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepositories()
        {
            this.client = new MongoClient("mongodb://localhost:27017");

        }
    }
}
