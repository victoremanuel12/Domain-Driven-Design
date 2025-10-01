using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class StartConsultationCommandHandler(IRepository<Consultation> repository) : ICommandHandler<StartConsultationCommand,Guid>
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            Consultation newConsultation = new Consultation(command.PatiendId);
            var entityId = await repository.InsertAsync(newConsultation);
            return entityId;
        }
    }
}
