using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messages.Web.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Home
        public ActionResult List()
        {
            return View();
        }
    }
}