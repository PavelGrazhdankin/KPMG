using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using TestAssignment.Models;

namespace TestAssignment.DB
{
    public class RepositoryFactory<T> where T : DbMainContext
    {
        public static Repository<T> CreateRepository(Action<object> creating, Action<object> created)
        {
            var connectionStringManager = new ConnectionStringManager();
            var connectionString = connectionStringManager.ReadConnectionString("ConnectionString");

            var res = IsServerConnected(connectionString);

            return res ? new Repository<T>(connectionString, creating, created) : null;
        }

        private static bool IsServerConnected(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    return ex.ClientConnectionId != Guid.Empty;
                }
            }
        }
    }
}