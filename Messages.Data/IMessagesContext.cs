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
    public interface IMessagesContext : IDisposable
    {
        DbSet<Message> Messages { get; }
        int SaveChanges();
    }

    public abstract class BaseMessagesContext : DbContext, IMessagesContext
    {
        public BaseMessagesContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Message> Messages { get; set; }

        int IMessagesContext.SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configure conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
