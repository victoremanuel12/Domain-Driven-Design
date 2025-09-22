using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities
{
    public class VitalSigns : Entity
    {
        public Guid ConsultationId { get; private set; } 
        public DateTime ReadingDateTime { get; init; }
        public decimal Temperature { get; init; }
        public int HeartRate { get; init; }
        public int RespirationRate { get; init; }
        public Consultation Consultation { get; set; }
        private VitalSigns() { }
        public VitalSigns(decimal temperature, int heartRate, int respirationRate)
        {
            Validate(temperature, heartRate, respirationRate);
            ReadingDateTime = DateTime.UtcNow;
            Temperature = temperature;
            HeartRate = heartRate;
            RespirationRate = respirationRate;
        }
        private void Validate(decimal temperature, int hearRate, int respiration)
        {
            if (temperature < 0 || hearRate < 0 || respiration < 0)
            {
                throw new ArgumentException("Invalid Vital Signs values");
            }
        }

    }
}
