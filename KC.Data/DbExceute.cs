using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC.Data
{
    public class DbExceute
    {
        static string connectionString;
        static DbExceute()
        {
            connectionString = ConfigurationManager.ConnectionStrings["KC"].ConnectionString;
        }

        public static void Exceute(SqlGenerator sqlGenerator, Action<SqlCommand> action)
        {            
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sqlGenerator.Statement, connection))
            {
                command.Parameters.AddRange(sqlGenerator.Parameters.ToArray());
                connection.Open();
                action?.Invoke(command);
            }            
        }
    }
}
