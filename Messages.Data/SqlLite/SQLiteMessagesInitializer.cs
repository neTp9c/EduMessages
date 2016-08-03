using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data.SqlLite
{
    public class SqLiteMessagesInitializer : SqliteDropCreateDatabaseWhenModelChanges<SqLiteMessagesContext>
    {
        public SqLiteMessagesInitializer(DbModelBuilder modelBuilder) : base(modelBuilder) { }

        protected override void Seed(SqLiteMessagesContext context)
        {

        }
    }
}
