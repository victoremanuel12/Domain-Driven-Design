using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Infra.Data.Repository.Interfaces;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Application.Handlers
{
    public class RegisterVitalSignsCommandHandler(IRepository<Consultation> repository, IEventStore eventStoreRepository) : ICommandHandler<RegisterVitalSignsCommand>
    {
        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            var vitals = command.VitalSigns.Select(v => new VitalSigns(v.Temperature, v.HeartRate, v.RespirationRate));
            entity.RegisterVitalSigns(vitals);
            await repository.UpdateAsync(entity);
        }

    }
}
