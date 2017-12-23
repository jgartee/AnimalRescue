using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnimalRescue.Core.Exceptions;

namespace AnimalRescue.Core
{
    public abstract class AggregateRoot
    {
        private readonly IList<IDomainEvent> _enqueuedDomainEvents = new List<IDomainEvent>();

        protected void EnqueueDomainEvent(IDomainEvent @event)
        {
            Guard.IsNotNullDomainEvent(@event);

            _enqueuedDomainEvents.Add(@event);
        }

        public void ClearEnqueuedDomainEvents()
        {
            _enqueuedDomainEvents.Clear();
        }

        public IEnumerable<IDomainEvent> GetEnqueuedDomainEvents()
        {
            return new ReadOnlyCollection<IDomainEvent>(_enqueuedDomainEvents);
        }

        private static class Guard
        {
            public static void IsNotNullDomainEvent(IDomainEvent @event)
            {
                if (@event == null)
                    throw new GuardException("Cannot enqueue a null domain event.");
            }
        }
    }
}
