
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;
using Wpm.SharedKernel.ValueObjects;

namespace Wpm.Management.Domain.Entities
{
    public class Pet : Entity
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public Weight? Weight { get; private set; }

        public WeihgtClass WeightClass { get; private set; }
        public string Color { get; set; }
        public SexOfPet SexOfPet { get; init; }
        public BreedId BreedId { get; set; }

        public Pet(Guid id, string name, int age, SexOfPet sexOfPet, string color, BreedId breedId)
        {
            Id = id;
            Name = name;
            Age = age;
            SexOfPet = sexOfPet;
            Color = color;
            BreedId = breedId;
        }
        public void SetWeight(Weight weight, IBreedService breedService)
        {
            Weight = weight;
            SetWeihgtClass(breedService);
            DomainEvents.PetWeightUpdated.Publish(new PetWeightUpdated(Id, Weight));
        }
        // O SetWeight exemplifica o Recurring Pattern porque cada vez que um peso é atribuído,
        // a regra de negócio associada (cálculo da WeightClass) é reexecutada automaticamente.
        private void SetWeihgtClass(IBreedService breedService)
        {
            var desiredBreed = breedService.GetBreed(BreedId.Value);
            var (from, to) = SexOfPet switch
            {
                SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
                SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
                _ => throw new NotImplementedException()
            };
            WeightClass = Weight.Value switch
            {
                _ when Weight.Value < from => WeihgtClass.Underweight,
                _ when Weight.Value > to => WeihgtClass.Overweight,
                _ => WeihgtClass.Ideal
            };
        }
    }
}
