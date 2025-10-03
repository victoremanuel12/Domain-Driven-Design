using static ClinicDbContext;

namespace Wpm.Clinic.Infra.Data.Repository.Interfaces
{
    public interface IEventStore
    {
        Task SaveAsync(ConsultationEventData @event);
        Task<IEnumerable<ConsultationEventData>> GetEventsForAggregate(string aggregateId);

        Task SaveChangesAsync();
    }
}
