namespace Wpm.Clinic.Domain.ValueObjects
{
    public record VitalSigns
    {

        public DateTime ReadingDateTime { get; init; }
        public Decimal Temperature { get; init; }
        public int HeartRate { get; init; }
        public int RespirationRate { get; init; }
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
