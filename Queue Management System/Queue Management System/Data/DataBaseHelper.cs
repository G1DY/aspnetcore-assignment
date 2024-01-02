using System;
using System.Globalization;
using Npgsql;

namespace Queue_Management_System.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

        private const string CheckInTableName = "CheckIn";
        private const string ServicePointsTableName = "ServicePoints";

        private const string CheckInTicketNumberColumn = "TicketNumber";
        private const string CheckInTimeColumn = "Time";
        private const string CheckInSelectedServiceColumn = "SelectedService";

        private const string ServicePointsServiceNameColumn = "ServiceName";

        public DataBaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            CreateTables();
        }
        private void CreateTables()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException(nameof(_connectionString), "cannot be null");
            }

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                //creates checkin table
                using (var cmd = new NpgsqlCommand($@"
                    CREATE TABLE IF NOT EXISTS CheckIn(
                    TicketNumber SERIAL PRIMARY KEY,
                    Time TIMESTAMP,
                    SelectedService VARCHAR(255))", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new NpgsqlCommand( $@"
                    CREATE TABLE IF NOT EXISTS ServicePoints(
                    ServicePointId SERIAL PRIMARY KEY,
                    ServiceName VARCHAR(255))", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public void CreateCheckInData(string data)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                var values = data.Split(',');

                var dateTimeString = values[1].Trim();

                if (DateTime.TryParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var checkInTime))
                {
                    using (var cmd = new NpgsqlCommand($"INSERT INTO {CheckInTableName} ({CheckInTicketNumberColumn}, {CheckInTimeColumn}, {CheckInSelectedServiceColumn}) VALUES (@TicketNumber, @Time, @SelectedService)", conn))
                    {
                        // adds checkindata to DB
                        cmd.Parameters.AddWithValue("TicketNumber", values[0].Trim());
                        cmd.Parameters.AddWithValue("CheckInTime", checkInTime);
                        cmd.Parameters.AddWithValue("SelectedService", values[2].Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // handles parsing error
                    Console.WriteLine("Error parsing date and time");
                }
            }
        }
        public void ReadCheckInData()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT * FROM {CheckInTableName}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[CheckInTicketNumberColumn]}");
                    }
                }
            }
        }

        public void CreateServicePointsData(string serviceName)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"INSERT INTO {ServicePointsTableName} ({ServicePointsServiceNameColumn}) VALUES (@ServiceName)", conn))
                {
                    cmd.Parameters.AddWithValue("ServiceName", serviceName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
