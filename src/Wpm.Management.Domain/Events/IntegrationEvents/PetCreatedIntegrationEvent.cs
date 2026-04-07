using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events.IntegrationEvents
{
    public record PetCreatedIntegrationEvent(Guid PetId, Guid BreedId) : IIntegrationEvent
    {
    }
}
