using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Entities
{
    public class Breed : Entity<BreedId>
    {
        public string Name { get; init; }
        public WeightRange FemaleIdealWeight { get; init; }
        public WeightRange MaleIdealWeight { get; init; }
        public Breed(BreedId id, string name, WeightRange femaleIdealWeight, WeightRange maleIdealWeight)
        {
            Id = id;
            Name = name;
            FemaleIdealWeight = femaleIdealWeight;
            MaleIdealWeight = maleIdealWeight;
        }
    }
}
