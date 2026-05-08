using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Application.Commands
{
    public record SetWeightCommand(PetId Id, decimal Weight);
    
}
