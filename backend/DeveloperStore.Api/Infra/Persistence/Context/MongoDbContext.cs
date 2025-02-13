using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DeveloperStore.Api.Infra.Persistence.Context;

public class MongoDbContext 
{
    readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {

        var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = mongoClient.GetDatabase(configuration.GetConnectionString("MongoDb"));
    }
}