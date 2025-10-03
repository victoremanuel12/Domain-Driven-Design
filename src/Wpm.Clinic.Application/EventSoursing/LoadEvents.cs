using Newtonsoft.Json;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.SaveEventSoursing
{
    public static class LoadEvents
    {
        public static async Task<Consultation> LoadEventsAsync(Guid Id, IEventStore repositoryEventStore)
        {
            var agregateId = $"Consultation-{Id}";
            var events = await repositoryEventStore.GetEventsForAggregate(agregateId);
            var domainEvents = events.Select(e =>
            {
                var assemblyQualifiedName = e.AssemblyQualifiedName;
                var type = Type.GetType(assemblyQualifiedName);
                var data = JsonConvert.DeserializeObject(e.Data, type!);
                return data as IDomainEvent;
            }); 
            var agregate = new Consultation(domainEvents!);
            return agregate;
        }
    }
}
