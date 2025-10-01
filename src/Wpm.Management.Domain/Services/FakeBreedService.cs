using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Services
{
    public class FakeBreedService : IBreedService
    {
        public readonly List<Breed> breeds = [
                new Breed(Guid.NewGuid(),"Bigou",new WeightRange(10m, 20m), new WeightRange(5.0m, 15.0m)),
                new Breed(Guid.NewGuid(),"PitBull",new WeightRange(28m, 40m), new WeightRange(5.0m, 20.0m))
            ];
        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Breed is not valid");
            }
            var result = breeds.Find(x => x.Id == id);
            return result ?? throw new ArgumentNullException("Breed was not found");
        }
    }
}
