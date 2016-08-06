using Messages.Data.Identity;
using Messages.Entities;
using Messages.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Messages.Data
{
    public interface IMessagesContext : IDisposable
    {
        DbSet<Message> Messages { get; }
        int SaveChanges();
    }

    public abstract class BaseMessagesContext : IdentityDbContext<User>, IMessagesContext
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
            //var test = DbConfiguration.DependencyResolver.GetService(typeof(IMessagesContextAccessor), null); ;

            base.OnModelCreating(modelBuilder);

            // configure conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Message>()
                        .HasRequired<User>(s => s.User)
                        .WithMany(s => s.Messages);
        }
    }
}
