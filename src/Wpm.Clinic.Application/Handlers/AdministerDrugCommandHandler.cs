using Wpm.Clinic.Application.Commands;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.CommandHandler;

namespace Wpm.Clinic.Application.Handlers
{
    public class AdministerDrugCommandHandler(IRepository<Consultation> repository) : ICommandHandler<AdministerDrugCommand>
    {
        public async Task Handle(AdministerDrugCommand command)
        {
            var entity = await repository.GetByIdAsync(command.ConsultationId) ?? throw new InvalidOperationException($"Consulta  {command.ConsultationId} não encontrado.");
            entity.AdministerDrug(command.DrugId, new Dose(command.Quantity, command.Unit));
            await repository.SaveChangesAsync();
        }
    }
}
