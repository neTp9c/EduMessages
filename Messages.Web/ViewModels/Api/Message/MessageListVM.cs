using Messages.Web.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Web.ViewModels.Api.Message
{
    public class MessageListVM
    {
        public IEnumerable<MessageVM> messages { get; set; }
        public IEnumerable<UserVM> users { get; set; }
    }
}