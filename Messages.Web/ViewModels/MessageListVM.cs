using Messages.Entities;
using Messages.Web.Navigation;
using System.Collections.Generic;

namespace Messages.Web.ViewModels
{

    public class MessageListVM
    {
        public IEnumerable<Message> Messages { get; set; }
        public Pager Pager { get; set; }
        public int TotalCount { get; set; }
    }
}