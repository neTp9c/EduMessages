using Messages.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data
{
    public class MsSqlMessagesContext : BaseMessagesContext
    {
        public MsSqlMessagesContext() : base("MessagesContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set initializer
            Database.SetInitializer(new MsSqlMessagesInitializer());
        }

        private void FixEfProviderServicesProblem()
        {
            // EntityFramework.SqlServer.dll will not automatically copy on project building to web project bin folder without it.
            // http://stackoverflow.com/a/19130718/1315751

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
