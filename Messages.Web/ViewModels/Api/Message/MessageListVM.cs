using Messages.Web.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Web.ViewModels.Api.Message
{
    public class MessageListVM
    {
        public IEnumerable<MessageVM> Messages { get; set; }
        public IEnumerable<UserVM> Users { get; set; }
        public int TotalMessagesCount { get; set; }
    }
}