using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public class UserClass : IUserClass
    {
        public UserClass()
        {
            
        }

        public SqlConnection SqlConnection { get; set; }


        public static SqlCommand CreateCommand(string commandName, params SqlParameter[] parameters)
        {
            var command = new SqlConnection(ConnectionManager.ConnectionString).CreateCommand();

            command.CommandText = commandName;

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddRange(parameters);

            return command;
        }

        //public SqlCommand CreateCommand(string commandName, params SqlParameter[] parameters)
        //{
        //    SqlCommand command = this.SqlConnection.CreateCommand();

        //    command.CommandText = commandName;

        //    command.CommandType = System.Data.CommandType.StoredProcedure;

        //    command.Parameters.AddRange(parameters);

        //    return command;
        //}
    }
}
