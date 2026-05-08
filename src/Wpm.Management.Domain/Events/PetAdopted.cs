using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events
{
    public record PetAdopted(PetId Id, string PetName, DateTime AdoptedAt) : IDomainEvent
    {
    }
}
