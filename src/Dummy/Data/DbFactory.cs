using System.Data;
using System.Data.SqlClient;

namespace Dummy.Data
{
    public sealed class DbFactory
    {
        public static IDbConnection GetConnection()        
            => new SqlConnection();

        public static IDbCommand GetCommand()
            => new SqlCommand();
    }
}