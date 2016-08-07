using Messages.Business;
using Messages.Business.Identity;
using Messages.Entities;
using Messages.Web.ViewModels;
using Messages.Web.ViewModels.Api.Account;
using Messages.Web.ViewModels.Api.Message;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Messages.Web.Controllers.Api
{
    [Authorize]
    public class MessagesController : ApiController
    {
        private readonly IMessagesManager _messagesManager;
        private readonly UserManager _userManager;

        public MessagesController(IMessagesManager messagesManager,
            UserManager userManager)
        {
            _messagesManager = messagesManager;
            _userManager = userManager;
        }

        [Route("api/v1/messages")]
        public async Task<IHttpActionResult> Add(MessageCreateVM messageCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());

            var message = new Message
            {
                Body = messageCreateVM.Body,
                CreatedUtc = DateTime.UtcNow,
                UserId = user.Id,
                User = user
            };

            _messagesManager.Create(message);

            var viewModel = new MessageFullVM
            {
                Id = message.Id,
                Body = message.Body,
                CreatedUtc = message.CreatedUtc,
                User = new UserVM
                {
                    Id = message.User.Id,
                    UserName = message.User.UserName
                }
            };

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [Route("api/v1/messages")]
        public ViewModels.Api.Message.MessageListVM GetMessages(int skip,  int take, string userId = null)
        {
            Expression<Func<Message, bool>> wherePredicate = null;

            if (userId != null)
            {
                wherePredicate = m => m.UserId == userId;
            }

            var messages = _messagesManager.GetMessages(
                skip: skip,
                take: take,
                wherePredicate: wherePredicate,
                includePaths: new string[] { "User" }
            );

            var messagesVM = messages.Select(m => new MessageVM {
                id = m.Id,
                userId = m.UserId,
                body = m.Body,
                createdUtc = m.CreatedUtc,
            });

            var usersVM = messages.Select(m => m.User).DistinctBy(u => u.Id).Select(u => new UserVM {
                Id = u.Id,
                UserName = u.UserName
            });

            var viewModel = new ViewModels.Api.Message.MessageListVM
            {
                Messages = messagesVM,
                Users = usersVM,
                TotalMessagesCount = _messagesManager.GetCount(wherePredicate)
            };

            return viewModel;
        }
    }
}
