using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Repositories;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Application.Handlers
{
    public class AdoptCommandHandler(IPetRepository _repository) : ICommandHandler<AdoptPetCommand>
    {
        public async Task Handle(AdoptPetCommand command)
        {
            var pet = await _repository.GetByIdAsync(command.Id);
            if (pet == null) throw new Exception($"Pet with id {command.Id} not found.");
            pet.Adopt();
        }
    }
}
