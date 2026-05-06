using Wpm.SharedKerbel.Abstract;

namespace Wpm.Rescue.Domain.Events.IntegrationEvents
{
    public record PetAdoptedIntegrationEvent(Guid Id,  string PetName, DateTime AdoptedAt) : IIntegrationEvent
    {
    }
}
