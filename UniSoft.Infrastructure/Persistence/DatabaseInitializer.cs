using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSoft.Infrastructure.Persistence
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLiteConnection");

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var createTablesQuery = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Email TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL,
                    FullName TEXT NOT NULL,
                    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );
                CREATE TABLE IF NOT EXISTS Applications (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Label TEXT NOT NULL,
                    Description TEXT,
                    Icon TEXT,
                    Version TEXT
                );
            ";

            connection.Execute(createTablesQuery);
        }
    }
}
