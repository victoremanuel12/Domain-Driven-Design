using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Services
{
    public class BreedService : IBreedService
    {
        private readonly List<Breed> _breeds =
        [
            new Breed(
                BreedId.Create(Guid.Parse("7f1bd38c-a795-45fd-bf82-1501f3b55057")),
                "Golden",
                new WeightRange(10m, 20m),
                new WeightRange(11m, 18m)
            ),

            new Breed(
                BreedId.Create(Guid.Parse("2a84a9a4-b6aa-4d3c-b6dc-c9f5a5cb7c21")),
                "PitBull",
                new WeightRange(28m, 40m),
                new WeightRange(16m, 32m)
            )
        ];

        public Breed? GetBreed(BreedId id)
        {
            if (id == null)
                throw new ArgumentException("Breed is not valid");

            return _breeds.FirstOrDefault(b => b.Id == id);
        }
    }
}