namespace Wpm.Clinic.Domain.ValueObjects
{
    public record DrugId
    {
        public Guid Value { get; init; }

        public DrugId(Guid value)
        {
            Validate(value);
            Value = value;
        }
        private void Validate(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException("DrugId", "The identifier is not valid");

            }

        }
        public static implicit operator DrugId(Guid id)
        {
            return new DrugId(id);
        }
    }
}
