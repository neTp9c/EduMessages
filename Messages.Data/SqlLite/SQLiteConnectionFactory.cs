using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace Messages.Data.SqlLite
{
    public class SqLiteConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new SQLiteConnection(nameOrConnectionString);
        }
    }
}
