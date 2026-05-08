namespace Wpm.Management.Domain.ValueObjects
{
    public sealed record PetId
    {
        public Guid Value { get; }

        private PetId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Invalid pet identifier");

            Value = value;
        }

        public static PetId Create(Guid existingGuid)
        {
            return new PetId(existingGuid);
        }

        public static PetId New()
        {
            Guid generatedGuid = Guid.NewGuid();

            return new PetId(generatedGuid);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
