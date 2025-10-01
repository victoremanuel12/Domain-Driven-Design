using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class SetDiagnosisCommandHandler(IRepository<Consultation> repository) : ICommandHandler<SetDiagnosisCommand>
    {
        public async Task Handle(SetDiagnosisCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            entity.SetDiagnosis(command.Diagnosis);
            await repository.UpdateAsync(entity);
        }
    }
}
