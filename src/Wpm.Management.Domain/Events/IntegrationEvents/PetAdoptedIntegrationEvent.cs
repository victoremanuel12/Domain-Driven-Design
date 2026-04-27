using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events.IntegrationEvents
{
    public record PetAdoptedIntegrationEvent(Guid Id,  string PetName, int PetWeight) : IIntegrationEvent
    {
    }
}
