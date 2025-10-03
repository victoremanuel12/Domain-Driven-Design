using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKernel;
using Wpm.SharedKernel.ValueObjects;

namespace Wpm.Clinic.Domain.Entities
{
    public class Consultation : AggregateRoot
    {
        private readonly List<DrugAdministration> administratedDrugs = new();
        private readonly List<VitalSigns> vitalSignsReadings = new();
        public DateTimeRange DateTimeRange { get; private set; }
        public Text? Diagnosis { get; private set; }
        public Text? Treatment { get; private set; }
        public PatiendId PatiendId { get; private set; }
        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus Status { get; private set; }
        public IReadOnlyCollection<DrugAdministration> AdministrateredDrugs => administratedDrugs;
        public IReadOnlyCollection<VitalSigns> VitalSignsReadings => vitalSignsReadings;
        public Consultation(IEnumerable<IDomainEvent> domainEvents)
        {
            Load(domainEvents);
        }
        public Consultation(PatiendId patiendId)
        {
            ApplyNewEvent(new Events.StartConsulation(Guid.NewGuid(), patiendId, DateTime.UtcNow));
        }

        public void SetWheight(Weight weight)
        {
            ApplyNewEvent(new Events.WeightUpdated(Id, weight));
        }

        public void SetDiagnosis(Text diagnosis)
        {
            ApplyNewEvent(new Events.DiagnosisUpdated(Id, diagnosis));
        }

        public void SetTreatment(Text treatment)
        {
            ApplyNewEvent(new Events.TreatmentUpdated(Id, treatment));
        }

        public void End()
        {
            ApplyNewEvent(new Events.ConsultationEnded(Id, DateTime.UtcNow));
        }


        public void AdministerDrug(DrugId drugId, Dose dose)
        {
            ValidateConsultationStatus();
            var newDrugAdministration = new DrugAdministration(drugId, dose);
            administratedDrugs.Add(newDrugAdministration);

        }
        public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
        {
            ValidateConsultationStatus();
            vitalSignsReadings.AddRange(vitalSigns);
        }
        private void ValidateConsultationStatus()
        {
            if (Status == ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("The consultations is already closed");
            }
        }

        protected override void ChangeStateByUsinDomainEvent(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case Events.StartConsulation e:
                    Id = e.Id;
                    PatiendId = e.PatiendId;
                    Status = ConsultationStatus.Open;
                    DateTimeRange = new DateTimeRange(e.StartAt);
                    break;
                case Events.DiagnosisUpdated e:
                    ValidateConsultationStatus();
                    Diagnosis = e.Diagnosis;
                    break;
                case Events.TreatmentUpdated e:
                    ValidateConsultationStatus();
                    Treatment = e.Treatment;
                    break;
                case Events.WeightUpdated e:
                    ValidateConsultationStatus();
                    CurrentWeight = e.Weight;
                    break;
                case Events.ConsultationEnded e:
                    ValidateConsultationStatus();
                    if (Diagnosis == null || Treatment == null || CurrentWeight == null) throw new InvalidOperationException("The consultation cannot be ended");
                    Status = ConsultationStatus.Closed;
                    DateTimeRange.SetEndTime(DateTime.UtcNow);
                    break;
            }
        }
    }
}
