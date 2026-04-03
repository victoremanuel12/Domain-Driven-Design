using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;
using Wpm.SharedKernel.ValueObjects;

public class Pet : Entity
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public Weight? Weight { get; private set; }
    public WeightClass WeightClass { get; private set; }
    public string Color { get; private set; }
    public SexOfPet SexOfPet { get; private set; }
    public BreedId BreedId { get; private set; }

    protected Pet() { }

    private Pet(Guid id, string name, int age, SexOfPet sexOfPet, string color, BreedId breedId)
    {
        Validate(name, age, color, breedId);

        Id = id;
        Name = name;
        Age = age;
        SexOfPet = sexOfPet;
        Color = color;
        BreedId = breedId;
    }

    public static Pet Create(Guid id, string name, int age, SexOfPet sexOfPet, string color, BreedId breedId)
    {
        var pet = new Pet(id, name, age, sexOfPet, color, breedId);

        DomainEvents.PetCreated.Publish(
            new PetCreated(pet.Id, pet.BreedId.Value)
        );

        return pet;
    }

    public void SetWeight(Weight weight, IBreedService breedService)
    {
        if (weight == null)
            throw new ArgumentException("Weight cannot be null");

        if (breedService == null)
            throw new ArgumentException("BreedService cannot be null");

        SetWeightClass(breedService);
        Weight = weight;

        DomainEvents.PetWeightUpdated.Publish(
            new PetWeightUpdated(Id, Weight)
        );
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var breed = breedService.GetBreed(BreedId.Value);

        if (breed == null)
            throw new ArgumentException("Breed not found");

        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (breed.MaleIdealWeight.From, breed.MaleIdealWeight.To),
            SexOfPet.Female => (breed.FemaleIdealWeight.From, breed.FemaleIdealWeight.To),
            _ => throw new NotSupportedException("Sex not supported")
        };

        WeightClass = CalculateWeightClass(Weight!.Value, from, to);
    }

    private WeightClass CalculateWeightClass(decimal weight, decimal from, decimal to)
    {
        if (weight < from)
            return WeightClass.Underweight;

        if (weight > to)
            return WeightClass.Overweight;

        return WeightClass.Ideal;
    }

    private void Validate(string name, int age, string color, BreedId breedId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");

        if (age < 0)
            throw new ArgumentException("Age cannot be negative");

        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color is required");

        if (breedId == null)
            throw new ArgumentException("BreedId is required");
    }
}