using Wpm.Clinic.Application.Dtos;
using Wpm.Clinic.Domain.Entities;

namespace Wpm.Clinic.Application.Commands
{
    public record StartConsultationCommand(Guid PatiendId);
    public record AdministerDrugCommand(Guid ConsultationId, Guid DrugId, decimal Quantity, UnitOfMeasure Unit);
    public record RegisterVitalSignsCommand(Guid ConsultationId, IEnumerable<VitalSignsDto> VitalSigns);
    public record SetDiagnosisCommand(Guid ConsultationId, string Diagnosis);
    public record SetTreatmentCommand(Guid ConsultationId, string Treatment);
    public record SetWeightCommand(Guid ConsultationId, decimal Weight);
    public record EndConsultationCommand(Guid ConsultationId);


}
