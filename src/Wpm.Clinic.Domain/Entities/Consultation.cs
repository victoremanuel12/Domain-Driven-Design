using Wpm.Clinic.Domain.ValueObjects;
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
        public PatiendId PatiendId { get; init; }
        public Weight? CurrentWeight { get; private set; }
        public ConsultationStatus Status { get; private set; }
        public IReadOnlyCollection<DrugAdministration> AdministrateredDrugs => administratedDrugs;
        public IReadOnlyCollection<VitalSigns> VitalSignsReadings => vitalSignsReadings;
        public Consultation(PatiendId patiendId)
        {
            Id = Guid.NewGuid();
            PatiendId = patiendId;
            Status = ConsultationStatus.Open;
            DateTimeRange = DateTime.UtcNow;
        }
        public void SetWheight(Weight weight)
        {
            ValidateConsultationStatus();
            CurrentWeight = weight;
        }
        public void SetDiagnosis(Text diagnosis)
        {
            ValidateConsultationStatus();
            Diagnosis = diagnosis;
        }
        public void SetTreatment(Text treatment)
        {
            ValidateConsultationStatus();
            Treatment = treatment;
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
        public void End()
        {
            ValidateConsultationStatus();
            if (Diagnosis == null || Treatment == null || CurrentWeight == null)
            {
                throw new InvalidOperationException("The consultation cannot be ended");
            }
            Status = ConsultationStatus.Closed;
            DateTimeRange.SetEndTime(DateTime.UtcNow);
        }
        private void ValidateConsultationStatus()
        {
            if (Status == ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("The consultations is already closed");
            }
        }
    }
}
