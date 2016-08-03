using System;
using System.Configuration;

namespace Messages.Data.DbConnections
{
    public class ConnectionStringSettingsAccessor
    {
        private ConnStringSettings _settings;

        public ConnStringSettings Settings()
        {
            if (_settings == null)
            {
                _settings = GetSettings();
            }
            return _settings;
        }

        private ConnStringSettings GetSettings()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["MessagesContext"];

            return new ConnStringSettings
            {
                ConnectionString = connectionStringSettings.ConnectionString,
                ProviderInvariantName = connectionStringSettings.ProviderName,
                Provider = GetConnectionStringProvider(connectionStringSettings.ProviderName)
            };
        }

        private ConnectionStringProviders GetConnectionStringProvider(string connectionStringProviderName)
        {
            switch (connectionStringProviderName)
            {
                case "System.Data.SqlClient":
                    return ConnectionStringProviders.SqlClient;
                case "System.Data.SQLite.EF6":
                case "System.Data.SQLite":
                    return ConnectionStringProviders.SQLite;
                default:
                    throw new ArgumentOutOfRangeException(
                        "connectionStringProviderName",
                        connectionStringProviderName,
                        "Current connection string provider is not suported.");
            }
        }
    }
}
