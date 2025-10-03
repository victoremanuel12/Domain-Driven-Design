using Newtonsoft.Json;
using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using Wpm.SharedKerbel.Abstract;
using static ClinicDbContext;
namespace Wpm.Clinic.Application.Handlers
{
    public class StartConsultationCommandHandler(IRepository<Consultation> repository, IEventStore eventStoreRepository) : ICommandHandler<StartConsultationCommand, Guid>
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            Consultation newConsultation = new Consultation(command.PatiendId);
            await repository.InsertAsync(newConsultation);
            await SaveEvent.SaveEventSoursing.SaveEventSoursingAsync(newConsultation, eventStoreRepository);
            return newConsultation.Id;
        }

    }
}
