using Autofac.Features.Metadata;
using Messages.Data.DbConnections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Data
{
    public interface IMessagesContextAccessor
    {
        IMessagesContext GetMessagesContext();
    }

    public class MessagesContextAccessor : IMessagesContextAccessor
    {
        private readonly ConnStringSettings _connectionStringSettings;
        private readonly IEnumerable<Meta<IMessagesContext>> _contexts;
        private IMessagesContext _messageContext;

        public MessagesContextAccessor(
            IConnectionStringSettingsAccessor _connectionStringSettingsAccessor,
            IEnumerable<Meta<IMessagesContext>> contexts)
        {
            _connectionStringSettings = _connectionStringSettingsAccessor.Settings();
            _contexts = contexts;
        }

        public IMessagesContext GetMessagesContext()
        {
            if (_messageContext == null)
            {
                _messageContext = SelectMessageContext();
            }
            return _messageContext;
        }

        private IMessagesContext SelectMessageContext() {
            foreach (var contextMeta in _contexts)
            {
                var connStringProvider = (ConnectionStringProviders)contextMeta.Metadata["ConnectionStringProvider"];
                if (connStringProvider == _connectionStringSettings.Provider)
                {
                    return contextMeta.Value;
                }
            }
            return null;
        }
    }
}
