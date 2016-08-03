using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Messages.Entities;
using Messages.Data;
using Messages.Data.SqlLite;
using System.Data.Entity;
using System.Linq;

namespace Messages.Business
{
    public interface IMessagesManager
    {
        void Create(Message message);
        IEnumerable<Message> GetMessages(int skip = 0, int take = int.MaxValue);
        IEnumerable<Message> GetMessages(Expression<Func<Message, bool>> wherePredicate, int skip = 0, int take = int.MaxValue);
    }

    public class MessagesManager : IMessagesManager
    {
        private readonly IMessagesContext _messagesContext;

        public MessagesManager(IMessagesContextAccessor messagesContextAccessor)
        {
            _messagesContext = messagesContextAccessor.GetMessagesContext();
        }

        public IEnumerable<Message> GetMessages(int skip = 0, int take = int.MaxValue)
        {
            return _messagesContext.Messages.Skip(skip).Take(take);
        }

        public IEnumerable<Message> GetMessages(Expression<Func<Message, bool>> wherePredicate, int skip = 0, int take = int.MaxValue)
        {
            return _messagesContext.Messages.Where(wherePredicate).Skip(skip).Take(take);
        }

        public void Create(Message message)
        {
            _messagesContext.Messages.Add(message);
            _messagesContext.SaveChanges();
        }
    }
}