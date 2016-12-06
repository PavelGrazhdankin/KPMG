using System.Configuration;
using System.Data.SqlClient;

namespace TestAssignment.Models
{
    public class ConnectionStringManager
    {
        public string ReadConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool NeedNewConnectionString(string connectionString)
        {
            var isValid = !string.IsNullOrWhiteSpace(connectionString);

            if (isValid)
            {
                try
                {
                    new SqlConnectionStringBuilder(connectionString);
                }
                catch
                {
                    isValid = false;
                }
            }
            return !isValid;
        }

        public void SaveConnectionString(string connectionString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = connectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}