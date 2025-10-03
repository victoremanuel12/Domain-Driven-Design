using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Domain.Events
{
    public record StartConsulation(Guid Id, Guid PatiendId, DateTime StartAt) : IDomainEvent;
    public record DiagnosisUpdated(Guid Id, string Diagnosis) : IDomainEvent;
    public record TreatmentUpdated(Guid Id, string Treatment) : IDomainEvent;
    public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvent;
    public record ConsultationEnded(Guid Id, DateTime EndedAt) : IDomainEvent;



}
