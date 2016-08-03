using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data
{
    public class MessagesInitializer : DropCreateDatabaseIfModelChanges<MessagesContext>
    {
        protected override void Seed(MessagesContext context)
        {
           base.Seed(context);
        }
    }
}
