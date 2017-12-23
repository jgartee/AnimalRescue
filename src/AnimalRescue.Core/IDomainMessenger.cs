using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalRescue.Core
{
    public interface IDomainMessenger
    {
        Task SendAsync(IDomainEvent @event);
        Task SendAsync(params IDomainEvent[] events);
        Task SendAsync(IEnumerable<IDomainEvent> events);
    }
}
