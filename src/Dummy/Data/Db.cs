using System;
using System.Data;
using System.Threading;

namespace Dummy.Data
{

    public class Db : IDb, IDisposable
    {

        protected string ConnectionString { get; }
        public IDbConnection Connection { get; private set; }
        public Db(string connectionString)
        {
            ConnectionString = connectionString;

            Connection = DbFactory.GetConnection();
            Connection.ConnectionString = connectionString;
        }

        public void Dispose()
        {
            Connection?.Dispose();
            Connection = null;
        }
    }
}