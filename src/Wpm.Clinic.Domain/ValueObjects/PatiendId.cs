namespace Wpm.Clinic.Domain.ValueObjects
{
    public record PatiendId
    {

        public Guid Value { get; set; }

        public PatiendId(Guid value)
        {
            Validate(value);
            Value = value;
        }

        private void Validate(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException("PatiendId", "The identifier is not valid");

            }

        }
        public static implicit operator PatiendId(Guid value)
        {
            return new PatiendId(value);
        }
        public static implicit operator Guid(PatiendId value)
        {
            return value.Value;
        }
    }


}

