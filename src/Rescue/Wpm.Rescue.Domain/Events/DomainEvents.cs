using Wpm.SharedKerbel.DomainEvent;

namespace Wpm.Rescue.Domain.Events
{
    public class DomainEvents
    {
        public static DomainEventDispatcher<AdoptionRequestCreated> AdoptionRequestCreated = new();

    }
}
