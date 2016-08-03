using Messages.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Messages.Data.Identity
{
    public class UserStore : UserStore<User>
    {
        public UserStore(IMessagesContextAccessor _messagesContextAccessor)
            : base(_messagesContextAccessor.GetMessagesContext() as DbContext)
        {

        }
    }
}
