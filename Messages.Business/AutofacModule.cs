using Autofac;

namespace Messages.Business
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Data.AutofacModule());

            builder.RegisterType<MessagesManager>().As<IMessagesManager>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
