using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.CommandHandler;

namespace Wpm.Clinic.Application.Handlers
{
    public class SetTreatmentCommandHandler(IRepository<Consultation> repository) : ICommandHandler<SetTreatmentCommand>
    {
        public async Task Handle(SetTreatmentCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            entity.SetTreatment(command.Treatment);
            await repository.UpdateAsync(entity);
        }


    }
}
