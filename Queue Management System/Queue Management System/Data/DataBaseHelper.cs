using System;
using Npgsql;

namespace Queue_Management_System.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

        private const string TableName = "QueueManagementSystem";

        private const string ColumnName = "column1";

        public DataBaseHelper(string connectionString) => _connectionString = connectionString;

        public void CreateData(string data)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"INSERT INTO {TableName} ({ColumnName}) VALUES (@data)", conn))
                {
                    cmd.Parameters.AddWithValue("data", data);
                    cmd.ExecuteNonQuery();
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

                using (var cmd = new NpgsqlCommand($"UPDATE {TableName} SET {ColumnName} = @newData WHERE id = @id", conn))
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

                using (var cmd = new NpgsqlCommand($"DELETE FROM {TableName} WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
