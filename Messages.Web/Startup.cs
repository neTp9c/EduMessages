using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Messages.Web.Startup))]
namespace Messages.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
            ConfigureAuth(app);
        }
    }
}