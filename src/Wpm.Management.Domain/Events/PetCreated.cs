using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events
{
    public record PetCreated(Guid Id, Guid BeedId) : IDomainEvent;

}
