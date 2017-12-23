using System;
using System.Collections.Generic;
using System.Linq;
using AnimalRescue.Core.Exceptions;

namespace AnimalRescue.Core
{
    public class RegistrationEventRouter : IEventRouter
    {
        private readonly IDictionary<Type, Action<object>> _handlers
            = new Dictionary<Type, Action<object>>();

        public void Register<T>(Action<T> handler)
        {
            _handlers[typeof(T)] = @event => handler((T) @event);
        }

        public void Dispatch(object eventMessage)
        {
            if (!_handlers.Any())
                throw new EventHandlersNotRegisteredException();

            if (!_handlers.TryGetValue(eventMessage.GetType(), out Action<object> handler))
                throw new EventHandlerNotFoundException();

            handler(eventMessage);
        }
    }
}
