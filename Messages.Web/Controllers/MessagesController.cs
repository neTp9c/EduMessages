using Messages.Business;
using Messages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messages.Web.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessagesManager _messagesManager;

        public MessagesController(IMessagesManager messagesManager)
        {
            _messagesManager = messagesManager;
        }


        public ActionResult List()
        {
            var message = new Message
            {
                CreatedUtc = DateTime.UtcNow,
                Body = Guid.NewGuid().ToString()
            };
            _messagesManager.Create(message);

            var messages = _messagesManager.GetMessages();
            return View();
        }
    }
}