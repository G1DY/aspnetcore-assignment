using System;
using System.Globalization;
using Npgsql;

namespace Queue_Management_System.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

        private const string TableName = "CheckIn";

        private const string ColumnName = "UserName";

        public DataBaseHelper(string connectionString) => _connectionString = connectionString;

        public void CreateData(string data)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                // Split the data string into individual values
                var values = data.Split(',');

                // Extract the date and time portion
                var dateTimeString = values[1].Trim();

                // Parse the date and time using the specified format
                if (DateTime.TryParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var checkInTime))
                {
                    // Exclude the auto-incremented Id column from the INSERT INTO statement
                    using (var cmd = new NpgsqlCommand($"INSERT INTO {TableName} (UserName, CheckInTime, SelectedService) VALUES (@UserName, @CheckInTime, @SelectedService)", conn))
                    {
                        // Add parameters with the corresponding values
                        cmd.Parameters.AddWithValue("UserName", values[0].Trim());
                        cmd.Parameters.AddWithValue("CheckInTime", checkInTime);
                        cmd.Parameters.AddWithValue("SelectedService", values[2].Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Handle parsing error
                    Console.WriteLine("Error parsing date and time");
                }
            }
        }

        public void ReadData()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT * FROM {TableName}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[ColumnName]}");
                    }
                }
            }
        }

        public void UpdateData(int id, string newData)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"UPDATE {TableName} SET {ColumnName} = @newData WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("newData", newData);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteData(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"DELETE FROM {TableName} WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
