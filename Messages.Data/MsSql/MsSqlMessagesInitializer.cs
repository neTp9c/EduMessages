using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data
{
    public class MsSqlMessagesInitializer : DropCreateDatabaseIfModelChanges<MsSqlMessagesContext>
    {
        protected override void Seed(MsSqlMessagesContext context)
        {
           base.Seed(context);
        }
    }
}
