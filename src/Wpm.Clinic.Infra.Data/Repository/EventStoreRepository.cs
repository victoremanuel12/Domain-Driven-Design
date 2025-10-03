using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using static ClinicDbContext;

namespace Wpm.Clinic.Infra.Data.Repository
{
    public class EventStoreRepository : IEventStore
    {
        private readonly ClinicDbContext _db;
        public EventStoreRepository(ClinicDbContext db) => _db = db;

        public async Task SaveAsync(ConsultationEventData @event)
        {
            await _db.ConsultationEvent.AddAsync(@event);
        }

        public async Task<IEnumerable<ConsultationEventData>> GetEventsForAggregate(string aggregateId)
        {
            return await _db.ConsultationEvent
                            .Where(e => e.AggregateName == aggregateId)
                            .OrderBy(e => e.Id)
                            .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }

}
