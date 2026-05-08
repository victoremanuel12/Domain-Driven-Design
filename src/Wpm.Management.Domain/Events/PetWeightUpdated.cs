using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Domain.Events
{
    public  record PetWeightUpdated(PetId Id, decimal Weight) : IDomainEvent;

}
