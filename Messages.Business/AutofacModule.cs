using Autofac;
using Messages.Business.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace Messages.Business
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Data.AutofacModule());

            builder.RegisterType<MessagesManager>().As<IMessagesManager>().InstancePerRequest();
            builder.RegisterType<UserManager>().InstancePerRequest();
            builder.RegisterType<SignInManager>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
