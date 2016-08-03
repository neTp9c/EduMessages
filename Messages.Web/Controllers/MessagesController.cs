using Messages.Business;
using Messages.Entities;
using Messages.Web.Navigation;
using Messages.Web.ViewModels;
using Microsoft.AspNet.Identity;
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

        public ActionResult List(PagerParameters pagerParameters)
        {
            var pager = new Pager(pagerParameters);
            var messages = _messagesManager.GetMessages((pager.Page - 1) * pager.PageSize, pager.PageSize);

            var viewModel = new MessageListVM
            {
                Messages = messages,
                Pager = pager,
                TotalCount = _messagesManager.GetCount()
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MessageCreateVM();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreateVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var message = new Message
                {
                    Body = viewModel.Body,
                    UserId = User.Identity.GetUserId()
                };

                _messagesManager.Create(message);
                return RedirectToAction("List");
            }

            return View(viewModel);
        }

        private bool IsMessageValid(MessageCreateVM viewModel)
        {
            return true;
        }
    }
}