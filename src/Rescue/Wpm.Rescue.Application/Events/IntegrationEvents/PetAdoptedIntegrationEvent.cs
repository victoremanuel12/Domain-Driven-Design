using Wpm.SharedKerbel.Abstract;

namespace Wpm.Rescue.Application.Events.IntegrationEvents
{
    public record PetAdoptedIntegrationEvent(Guid Id, string PetName, DateTime AdoptedAt) : IIntegrationEvent
    {
    }
}
