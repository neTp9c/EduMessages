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
    public class MessagesContext : DbContext
    {
        public MessagesContext() : base("MessagesContext")
        {

        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private void FixEfProviderServicesProblem()
        {
            // EntityFramework.SqlServer.dll will not automatically copy on project building to web project bin folder without it.
            // http://stackoverflow.com/a/19130718/1315751

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
