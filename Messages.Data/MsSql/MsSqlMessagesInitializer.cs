using System.Data.Entity;

namespace Messages.Data.MsSql
{
    public class MsSqlMessagesInitializer : DropCreateDatabaseIfModelChanges<MsSqlMessagesContext>
    {
        protected override void Seed(MsSqlMessagesContext context)
        {
           base.Seed(context);
        }
    }
}
