
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;

public class MyDatabaseService
{
    private readonly string _connectionString;

    public MyDatabaseService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void ConnectToDatabase()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            // Perform database operations
            // ...

            Console.WriteLine("Connected to MySQL database.");

            connection.Close();
        }
    }
}

