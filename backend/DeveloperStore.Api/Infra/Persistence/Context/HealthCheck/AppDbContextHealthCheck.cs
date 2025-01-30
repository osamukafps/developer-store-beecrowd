using Npgsql;

namespace DeveloperStore.Api.Infra.Persistence.Context.HealthCheck;

public static class AppDbContextHealthCheck
{
    public static void CheckConnection(string connectionString)
    {
        try
        {
            NpgsqlConnection connection = new(connectionString);
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Sucessfully opened connection to PostgreSQL.");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}