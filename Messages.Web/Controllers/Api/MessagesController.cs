using Messages.Business;
using Messages.Entities;
using Messages.Web.ViewModels.Api.Account;
using Messages.Web.ViewModels.Api.Message;
using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Messages.Web.Controllers.Api
{
    public class MessagesController : ApiController
    {
        private readonly IMessagesManager _messagesManager;
        public MessagesController(IMessagesManager messagesManager)
        {
            _messagesManager = messagesManager;
        }

        [Route("api/v1/messages")]
        public MessageListVM GetMessages(int skip,  int take, string userId = null)
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
                id = u.Id,
                userName = u.UserName
            });

            var viewModel = new MessageListVM
            {
                messages = messagesVM,
                users = usersVM
            };

            return viewModel;
        }
    }
}
