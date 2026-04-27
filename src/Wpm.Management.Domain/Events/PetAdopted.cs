using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events
{
    public record PetAdopted(Guid Id, string PetName, DateTime AdoptedAt) : IDomainEvent
    {
    }
}
