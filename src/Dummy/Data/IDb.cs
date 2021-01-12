using System.Data;

namespace Dummy.Data
{
    public interface IDb
    {
        IDbConnection Connection { get; }

        void Dispose();
    }
}