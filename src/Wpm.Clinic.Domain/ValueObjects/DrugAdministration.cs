namespace Wpm.Clinic.Domain.ValueObjects
{
    public record DrugAdministration
    {

        public DrugId DrugId { get; init; }
        public Dose Dose { get; init; }

        public DrugAdministration() { }
        public DrugAdministration(DrugId drugId, Dose dose)
        {
            DrugId = drugId;
            Dose = dose;
        }
    }
}
