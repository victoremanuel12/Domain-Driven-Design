using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class SetWeightCommandHandler(IRepository<Consultation> repository) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            entity.SetWheight(command.Weight);
            await repository.UpdateAsync(entity);
        }
    }
}
