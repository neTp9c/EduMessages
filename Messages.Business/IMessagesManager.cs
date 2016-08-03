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

        IEnumerable<Message> GetMessages(int skip, int take);

        IEnumerable<Message> GetMessages(
            int skip = 0,
            int take = int.MaxValue,
            Expression<Func<Message, bool>> wherePredicate = null,
            IEnumerable<string> includePaths = null);

        int GetCount();
        int GetCount(Expression<Func<Message, bool>> wherePredicate);
    }

    public class MessagesManager : IMessagesManager
    {
        private readonly IMessagesContext _messagesContext;

        public MessagesManager(IMessagesContextAccessor messagesContextAccessor)
        {
            _messagesContext = messagesContextAccessor.GetMessagesContext();
        }

        public void Create(Message message)
        {
            if (message.CreatedUtc == default(DateTime))
            {
                message.CreatedUtc = DateTime.UtcNow;
            }

            _messagesContext.Messages.Add(message);
            _messagesContext.SaveChanges();
        }

        public IEnumerable<Message> GetMessages(int skip, int take)
        {
            return GetMessages(
                skip: skip,
                take: take,
                wherePredicate: null,
                includePaths: null);
        }

        public IEnumerable<Message> GetMessages(
            int skip = 0,
            int take = int.MaxValue,
            Expression<Func<Message, bool>> wherePredicate = null,
            IEnumerable<string> includePaths = null)
        {
            var query = _messagesContext.Messages.AsQueryable<Message>();

            if(wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            }

            query = query.OrderByDescending(m => m.CreatedUtc);

            if(skip > 0)
            {
                query = query.Skip(skip);
            }

            if(take < int.MaxValue)
            {
                query = query.Take(take);
            }

            if(includePaths != null)
            {
                foreach(var includePath in includePaths)
                {
                    query = query.Include(includePath);
                }
            }

            return query.ToList();
        }

        public int GetCount()
        {
            return GetCount(null);
        }

        public int GetCount(Expression<Func<Message, bool>> wherePredicate)
        {
            var query = _messagesContext.Messages.AsQueryable<Message>();

            if (wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            }

            return query.Count();
        }
    }
}