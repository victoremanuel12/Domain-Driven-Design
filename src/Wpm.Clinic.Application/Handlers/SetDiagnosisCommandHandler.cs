using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Application.SaveEventSoursing;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class SetDiagnosisCommandHandler(IRepository<Consultation> repository, IEventStore eventStoreRepository) : ICommandHandler<SetDiagnosisCommand>
    {
        public async Task Handle(SetDiagnosisCommand command)
        {
            var entity = await LoadEvents.LoadEventsAsync(command.ConsultationId, eventStoreRepository)
                   ?? throw new InvalidOperationException($"Consulta {command.ConsultationId} não encontrado.");

            entity.SetDiagnosis(command.Diagnosis);

            await SaveEvent.SaveEventSoursing.SaveEventSoursingAsync(entity, eventStoreRepository);
        }
    }
}
