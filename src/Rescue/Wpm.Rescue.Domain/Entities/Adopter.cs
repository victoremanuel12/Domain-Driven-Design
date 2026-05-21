using Wpm.Rescue.Domain.Events;
using Wpm.Rescue.Domain.Exceptions;
using Wpm.Rescue.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Rescue.Domain.Entities
{
    public class Adopter : Entity<Guid>
    {
        public Guid Id { get; init; }
        public AdopterName Name { get; private set; }
        public AdopterQuestionnaire Questionnaire { get; private set; }
        public AdopterAddress Address { get; private set; }

        public Adopter(Guid id)
        {
            Id = id;
        }

        public void SetName(AdopterName name)
        {
            Name = name;
        }

        public void SetQuestionnaire(AdopterQuestionnaire questionnaire)
        {
            Questionnaire = questionnaire;
        }

        public void SetAddress(AdopterAddress address)
        {
            Address = address;
        }

        public void RequestToAdopt(RescuedAnimalId petId)
        {
            ValidateStateForAdoption();

            DomainEvents.AdoptionRequestCreated.Publish(new AdoptionRequestCreated(petId, Id));
        }

        private void ValidateStateForAdoption()
        {
            if (Name == null)
            {
                throw new InvalidAdopterStateException("Adopter name is missing");
            }

            if (Questionnaire == null)
            {
                throw new InvalidAdopterStateException("Adopter questionnaire is missing");
            }

            if (Address == null)
            {
                throw new InvalidAdopterStateException("Adopter address is missing");
            }
        }
    }
}
