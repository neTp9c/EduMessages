using Messages.Business;
using Messages.Business.Identity;
using Messages.Entities;
using Messages.Entities.Identity;
using Messages.Web.ViewModels.Api.Account;
using Messages.Web.ViewModels.Api.Message;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Messages.Web.Controllers.Api
{
    [Authorize]
    public class AccountController : ApiController
    {
        private UserManager _userManager;

        public AccountController(
            UserManager userManager)
        {
            _userManager = userManager;
        }

        [Route("api/v1/account/register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok();
        }

        private IHttpActionResult BadRequest(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return BadRequest(ModelState);
        }
    }
}