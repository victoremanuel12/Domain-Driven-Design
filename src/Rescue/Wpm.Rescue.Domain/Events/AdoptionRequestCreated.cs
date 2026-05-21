using Wpm.SharedKerbel.Abstract;

namespace Wpm.Rescue.Domain.Events
{
    public record AdoptionRequestCreated(Guid RescuedAnimalId, Guid AdopterId) : IDomainEvent {}
}
