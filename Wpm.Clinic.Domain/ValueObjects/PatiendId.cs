namespace Wpm.Clinic.Domain.ValueObjects
{
    public record PatiendId
    {

        public Guid Id { get; set; }

        public PatiendId(Guid id)
        {
            Validate(id);
            Id = id;
        }

        private void Validate(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("PatiendId", "The identifier is not valid");

            }

        }
        public static implicit operator PatiendId(Guid id)
        {
            return new PatiendId(id);
        }
    }


}

