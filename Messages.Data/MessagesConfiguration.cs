using Messages.Data.DbConnections;
using Messages.Data.SqlLite;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Data.SQLite.EF6;


namespace Messages.Data
{
    public class MessagesConfiguration : DbConfiguration
    {
        public MessagesConfiguration()
        {
            var connStringSettingsAccessor = new ConnectionStringSettingsAccessor();
            var connStringSettings = connStringSettingsAccessor.Settings();

            switch (connStringSettings.Provider)
            {
                case ConnectionStringProviders.SqlClient:
                    SetDefaultConnectionFactory(new SqlConnectionFactory());
                    SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
                    break;
                case ConnectionStringProviders.SQLite:
                    // http://stackoverflow.com/a/23237737/1315751
                    SetDefaultConnectionFactory(new SqLiteConnectionFactory());
                    SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
                    SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
                    SetProviderServices("System.Data.SQLite",
                        (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
                    break;
                default:
                    break;
            }
        }
    }
}
