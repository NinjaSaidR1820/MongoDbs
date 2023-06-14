using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbs.Models;
using System.Collections.ObjectModel;

namespace MongoDbs.Repositories
{
    public class ClienteCollection : IClienteCollection
    {

        internal MongoDBRepositories repositories = new MongoDBRepositories();
        private IMongoCollection<Clientes> Collection;

        public ClienteCollection()
        {
            Collection = repositories.db.GetCollection<Clientes>("Cliente");
        }



        public async Task DeleteCliente(string Id)
        {

            try
            {
                var filter = Builders<Clientes>.Filter.Eq(s => s.id, new ObjectId(Id));
                await Collection.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Clientes>> GetAllClientes()
        {
            try
            {
                return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
               

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Clientes> GetClienteById(string Id)
        {
            try
            {

                return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } })
                                .Result.FirstAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task InsertCliente(Clientes Cliente)
        {
            await Collection.InsertOneAsync(Cliente);  
        }

        public async Task UpdateCliente(Clientes Cliente)
        {
            try
            {
                var filter = Builders<Clientes>.Filter
                    .Eq(s => s.id, Cliente.id);


                await Collection.ReplaceOneAsync(filter, Cliente);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
