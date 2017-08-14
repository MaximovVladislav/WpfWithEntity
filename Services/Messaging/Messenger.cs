using System;
using System.Collections.Generic;

namespace Services.Messaging
{
    /// <summary>
    /// Реализация интерфейса <see cref="IMessenger"/>
    /// </summary>
    public class Messenger : IMessenger
    {
        private Dictionary<Type, List<Action<IMessage>>> _recipients = new Dictionary<Type, List<Action<IMessage>>>();

        private static volatile IMessenger _defaultInstance;
        private static readonly object _creationLock = new object();

        public static IMessenger Default
        {
            get
            {
                if (_defaultInstance == null)
                {
                    lock (_creationLock)
                    {
                        if (_defaultInstance == null)
                        {
                            _defaultInstance = new Messenger();
                        }
                    }
                }

                return _defaultInstance;
            }
        }

        public void Register<TMessage>(Action<TMessage> action) where TMessage : IMessage
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Action<IMessage> concreteAction = m => action((TMessage)m);

            Type messageType = typeof(TMessage);

            if (_recipients.ContainsKey(messageType))
            {
                if (_recipients[messageType] != null)
                {
                    _recipients[messageType].Add(concreteAction);
                }
                else
                {
                    _recipients[messageType] = new List<Action<IMessage>> { concreteAction };
                }
            }
            else
            {
                _recipients.Add(messageType, new List<Action<IMessage>> { concreteAction });
            }
        }

        public void Send<TMessage>(TMessage message) where TMessage : IMessage
        {
            Type messageType = typeof(TMessage);

            if (_recipients.ContainsKey(messageType))
            {
                foreach (var action in _recipients[messageType])
                {
                    action.Invoke(message);
                }
            }
        }
    }
}