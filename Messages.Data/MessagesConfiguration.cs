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

            // MS SQL Server
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}
