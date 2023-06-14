using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbs.Models
{
    public class Clientes
    {
    
       [BsonId]
       public ObjectId id { get; set; }
       public string firstName { get; set; }
       public string lastName { get; set; }
       public string category { get; set; }
       public DateTime fecha { get; set; }

    

    }
}
