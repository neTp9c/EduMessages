using Messages.Data;
using Messages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Business
{
    public class MessagesManager
    {
        private readonly MessagesContext _messagesContext;

        public MessagesManager()
        {
            _messagesContext = new MessagesContext();
        }

        public IEnumerable<Message> GetMessages(int skip = 0, int take = Int32.MaxValue)
        {
            return _messagesContext.Messages.Skip(skip).Take(take);
        }

        public IEnumerable<Message> GetMessages(Expression<Func<Message, bool>> wherePredicate, int skip = 0, int take = Int32.MaxValue)
        {
            return _messagesContext.Messages.Where(wherePredicate).Skip(skip).Take(take);
        }
    }
}
