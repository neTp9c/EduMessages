using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.Web.ViewModels.Api.Message
{
    public class MessageVM
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string body { get; set; }
        public DateTime createdUtc { get; set; }
    }
}