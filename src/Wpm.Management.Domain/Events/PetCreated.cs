using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events
{
    public record PetCreated(PetId Id, BreedId BreedId) : IDomainEvent;

}
