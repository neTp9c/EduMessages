namespace Messages.Data.DbConnections
{
    public class ConnStringSettings
    {
        public string ConnectionString { get; set; }
        public string ProviderInvariantName { get; set; }
        public ConnectionStringProviders Provider { get; set; }
    }
}
