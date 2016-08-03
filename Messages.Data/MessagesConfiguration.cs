using Messages.Data.DbConnections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data
{
    public class MessagesConfiguration : DbConfiguration
    {
        public MessagesConfiguration()
        {
            SetDatabaseInitializer(new MessagesInitializer());

            var connStringSettingsAccessor = new ConnectionStringSettingsAccessor();
            var connStringSettings = connStringSettingsAccessor.Settings();

            switch (connStringSettings.Provider)
            {
                case ConnectionStringProviders.SqlClient:
                    SetDefaultConnectionFactory(new SqlConnectionFactory());
                    SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
                    break;
                case ConnectionStringProviders.SQLite:
                    break;
                default:
                    break;
            }
        }
    }
}
