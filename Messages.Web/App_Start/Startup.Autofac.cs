using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Messages.Web
{
    public partial class Startup
    {
        public void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            BuildMvc(builder);
            BuildWebApi(builder);
            BuildCustom(builder);

            var container = builder.Build();

            RegisterForMvc(container);
            RegisterForOwin(app, container);
            RegisterForWebApi(container);
        }

        private void BuildMvc(ContainerBuilder builder)
        {
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
        }

        private void BuildWebApi(ContainerBuilder builder)
        {
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
        }

        private void BuildCustom(ContainerBuilder builder)
        {
            builder.RegisterModule(new Business.AutofacModule());

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>().InstancePerRequest();
        }

        private void RegisterForMvc(IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterForOwin(IAppBuilder app, IContainer container)
        {
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private void RegisterForWebApi(IContainer container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}