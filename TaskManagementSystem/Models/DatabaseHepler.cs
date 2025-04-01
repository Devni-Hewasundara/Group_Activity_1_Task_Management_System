using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Models
{
    public class DatabaseModel
    {
        private readonly string _connectionString;

        public DatabaseModel()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "CREATE TABLE IF NOT EXISTS Tasks (" +
                    "Id INT AUTO_INCREMENT PRIMARY KEY, " +
                    "Name VARCHAR(100) NOT NULL, " +
                    "Date DATE NOT NULL, " +
                    "Time TIME NOT NULL, " +
                    "IsCompleted BOOLEAN DEFAULT FALSE)", connection);
                command.ExecuteNonQuery();
            }
        }

        public ObservableCollection<TaskHelper> GetTasks()
        {
            var tasks = new ObservableCollection<TaskHelper>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Tasks", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskHelper
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Date = reader.GetDateTime("Date"),
                            Time = reader.GetTimeSpan("Time"),
                            IsCompleted = reader.GetBoolean("IsCompleted")
                        });
                    }
                }
            }

            return tasks;
        }

        public void AddTask(TaskHelper task)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "INSERT INTO Tasks (Name, Date, Time, IsCompleted) VALUES (@Name, @Date, @Time, @IsCompleted)",
                    connection);

                command.Parameters.AddWithValue("@Name", task.Name);
                command.Parameters.AddWithValue("@Date", task.Date);
                command.Parameters.AddWithValue("@Time", task.Time);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateTask(TaskHelper task)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "UPDATE Tasks SET Name = @Name, Date = @Date, Time = @Time, IsCompleted = @IsCompleted WHERE Id = @Id",
                    connection);

                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@Name", task.Name);
                command.Parameters.AddWithValue("@Date", task.Date);
                command.Parameters.AddWithValue("@Time", task.Time);
                command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Tasks WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
