using SQLite.CodeFirst;
using System.Data.Entity;

namespace Messages.Data.SqlLite
{
    public class SqLiteMessagesInitializer : SqliteDropCreateDatabaseWhenModelChanges<SqLiteMessagesContext>
    {
        public SqLiteMessagesInitializer(DbModelBuilder modelBuilder) : base(modelBuilder) { }

        protected override void Seed(SqLiteMessagesContext context)
        {
            base.Seed(context);
        }
    }
}
