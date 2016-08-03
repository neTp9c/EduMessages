using Autofac;
using Messages.Data.DbConnections;
using Messages.Data.Identity;
using Messages.Data.MsSql;
using Messages.Data.SqlLite;

namespace Messages.Data
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MsSqlMessagesContext>().As<IMessagesContext>()
                .WithMetadata("ConnectionStringProvider", ConnectionStringProviders.SqlClient)
                .InstancePerRequest();

            builder.RegisterType<SqLiteMessagesContext>().As<IMessagesContext>().InstancePerRequest()
                .WithMetadata("ConnectionStringProvider", ConnectionStringProviders.SQLite)
                .InstancePerRequest();

            builder.RegisterType<ConnectionStringSettingsAccessor>().As<IConnectionStringSettingsAccessor>().SingleInstance();
            builder.RegisterType<MessagesContextAccessor>().As<IMessagesContextAccessor>().InstancePerRequest();

            builder.RegisterType<UserStore>();

            base.Load(builder);
        }
    }
}
