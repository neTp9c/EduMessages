using Autofac;
using Messages.Business.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;

namespace Messages.Web.Services
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public SimpleAuthorizationServerProvider()
        {
            
        }

        public async override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // any client can use api
            // example of client validation http://stackoverflow.com/a/24350699/1315751
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // http://stackoverflow.com/a/36769653/1315751
            // need add depencies to the constractor (see another answer on same page)
            var autofacLifetimeScope = Autofac.Integration.Owin.OwinContextExtensions.GetAutofacLifetimeScope(context.OwinContext);
            var userManager = autofacLifetimeScope.Resolve<UserManager>();
            var signInManager = autofacLifetimeScope.Resolve<SignInManager>();

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = await signInManager.CreateUserIdentityAsync(user);

            context.Validated(identity);
        }
    }
}