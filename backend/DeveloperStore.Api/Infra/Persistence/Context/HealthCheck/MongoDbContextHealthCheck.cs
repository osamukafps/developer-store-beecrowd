using MongoDB.Driver;

namespace DeveloperStore.Api.Infra.Persistence.Context.HealthCheck;

public static class MongoDbContextHealthCheck 
{
    public static void CheckConnection(string connectionString, string databaseName)
    {
        try
        {
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);

            var check = database.ListCollectionNames().ToList();
            Console.WriteLine("Sucessfully opened connection to MongoDb.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}