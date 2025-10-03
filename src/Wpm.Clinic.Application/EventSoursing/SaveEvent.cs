using Newtonsoft.Json;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using static ClinicDbContext;

namespace Wpm.Clinic.Application.SaveEvent
{
    public static class SaveEventSoursing
    {
        public static async Task SaveEventSoursingAsync(Consultation consultation, IEventStore eventStoreRepository)
        {
            var aggregateId = $"Consultation-{consultation.Id}";
            var changes = consultation.GetChanges().Select(e => new ConsultationEventData(
                Guid.NewGuid(),
                aggregateId,
                e.GetType().Name,
                JsonConvert.SerializeObject(e),
                e.GetType().AssemblyQualifiedName
                )
            );
            if (!changes.Any()) return;

            foreach (var change in changes)
            {
                await eventStoreRepository.SaveAsync(change);
            }
            await eventStoreRepository.SaveChangesAsync();
            consultation.ClearChanges();
        }
    }
}
