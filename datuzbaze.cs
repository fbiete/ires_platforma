using System;
using System.Data.SQLite;

public class Database
{
    private const string DbFile = "Data Source=iresDB.sqlite;Version=3;";

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(DbFile);
    }

    public static void Initialize()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            string createClients = @"CREATE TABLE IF NOT EXISTS Clients (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        FullName TEXT NOT NULL,
                                        Email TEXT NOT NULL UNIQUE
                                    );";

            string createCars = @"CREATE TABLE IF NOT EXISTS Cars (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Model TEXT NOT NULL,
                                        HourlyRate REAL NOT NULL,
                                        KmRate REAL NOT NULL
                                  );";

            string createRentals = @"CREATE TABLE IF NOT EXISTS Rentals (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        ClientId INTEGER NOT NULL,
                                        CarId INTEGER NOT NULL,
                                        StartTime DATETIME NOT NULL,
                                        EndTime DATETIME,
                                        KmDriven REAL,
                                        TotalAmount REAL,
                                        FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                                        FOREIGN KEY (CarId) REFERENCES Cars(Id)
                                  );";

            SQLiteCommand command = new SQLiteCommand(createClients + createCars + createRentals, connection);
            command.ExecuteNonQuery();
        }
    }
}
