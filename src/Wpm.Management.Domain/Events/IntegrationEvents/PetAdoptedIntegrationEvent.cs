using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events.IntegrationEvents
{
    public record PetAdoptedIntegrationEvent(PetId Id,  string PetName, DateTime AdoptedAt) : IIntegrationEvent
    {
    }
}
