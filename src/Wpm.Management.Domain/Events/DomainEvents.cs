using Wpm.SharedKerbel.DomainEvent;

namespace Wpm.Management.Domain.Events
{
    public class DomainEvents
    {
        public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdated = new();
    }
}
