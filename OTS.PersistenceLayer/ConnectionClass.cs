using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using OTS.Utilities;

namespace OTS.PersistenceLayer
{
    public class ConnectionClass
    {
        //Define a New Sql Connection        
        public static SqlConnection connDatabase = new SqlConnection();
        static string connectionString;

        /// <summary>
        /// Opens a sql connection
        /// </summary>
        public static SqlConnection OpenConnection()
        {
            //String to Connect to database
            connectionString = (string)ConfigurationManager.ConnectionStrings[AppConstants.CONNECTION_STRING].ToString();

            ////Checks if current connection state is closed
            if (connDatabase.State == ConnectionState.Closed)
            {
                connDatabase.ConnectionString = connectionString;
                connDatabase.Open();
            }
            return connDatabase;
        }
    }
}