using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public class ConnectionManager
    {
        static ConnectionManager()
        {
            var connection = Tools.Configuartion.ConfigurationService.ReadSection<Connection>("Connection");

#if DEBUG
            ConnectionManager.ConnectionString = $"Server=.;DataBase={connection.DataBase};Trusted_Connection=Yes;";
#else

            //ConnectionManager.ConnectionString = $"Server={connection.Server.Replace(@"\\", @"\")};DataBase={connection.DataBase};UID={connection.UID};PWD={connection.Password};";
            ConnectionManager.ConnectionString = $"Server={connection.Server.Replace(@"\\", @"\")};DataBase={connection.DataBase};Trusted_Connection=Yes;";
#endif
        }


        public static string ConnectionString { get; }

        public static string CheckConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection = new SqlConnection(ConnectionManager.ConnectionString);

                connection.Open();

                return true.ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();

                    connection.Dispose();
                }
            }
        }


    }
}
