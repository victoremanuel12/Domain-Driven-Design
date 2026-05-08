namespace Wpm.Management.Domain.ValueObjects
{
    public sealed record BreedId
    {
        public Guid Value { get; }

        private BreedId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Invalid breed identifier");

            Value = value;
        }

        public static BreedId Create(Guid existingGuid)
        {
            return new BreedId(existingGuid);
        }

        public static BreedId New()
        {
            Guid generatedGuid = Guid.NewGuid();

            return new BreedId(generatedGuid);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}