using Messages.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messages.Web.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessagesManager _messagesManager;

        public MessagesController()
        {
            _messagesManager = new MessagesManager();
        }


        public ActionResult List()
        {
            var messages = _messagesManager.GetMessages();
            return View();
        }
    }
}