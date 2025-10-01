using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class EndConsultationCommandHandler(IRepository<Consultation> repository) : ICommandHandler<EndConsultationCommand>
    {
        public async Task Handle(EndConsultationCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            entity.End();
            await repository.UpdateAsync(entity);
        }
    }
}
