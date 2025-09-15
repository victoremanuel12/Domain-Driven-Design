using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Infra.Data
{
    public class BreedService : IBreedService
    {
        public readonly List<Breed> breeds =
            [
                new Breed(Guid.Parse("7f1bd38c-a795-45fd-bf82-1501f3b55057"), "Golden", new WeightRange(10m,20m), new WeightRange(11m,18m)),
                new Breed(Guid.Parse("7f1bd38c-a795-45fd-bf82-1501f3b55057"), "PitBull", new WeightRange(28m,40m), new WeightRange(16m,32m))
            ];
        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException("Breed is not valid");
            var result = breeds.FirstOrDefault(b => b.Id == id);
            return result ?? throw new ArgumentException("Breed not found"); ;

        }

    }
}
