using Messages.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data.SqlLite
{
    public class SqLiteMessagesContext : BaseMessagesContext
    {
        public SqLiteMessagesContext() : base("MessagesContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set initializer
            Database.SetInitializer(new SqLiteMessagesInitializer(modelBuilder));
        }


        //private void FixSQLiteServicesProblem()
        //{
        //    // it doesn't work
        //    // var instance = System.Data.SQLite.SQLiteFactory.Instance;

        //    // i use post build event in web (target) project insted
        //    // xcopy /Y "$(SolutionDir)Messages.Data\bin\$(ConfigurationName)\x86\SQLite.Interop.dll" "$(ProjectDir)bin\x86\"
        //    // xcopy / Y "$(SolutionDir)Messages.Data\bin\$(ConfigurationName)\x64\SQLite.Interop.dll" "$(ProjectDir)bin\x64\"
        //}
    }
}
