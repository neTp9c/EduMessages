using Messages.Web.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Web.ViewModels.Api.Message
{
    public class MessageFullVM
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedUtc { get; set; }

        public UserVM User { get; set; }
    }
}