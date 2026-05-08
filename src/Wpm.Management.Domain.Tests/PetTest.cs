using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class PetTest
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var service = new FakeBreedService();
        var b1 = BreedId.New();
        var pet1 = Pet.Create("Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = Pet.Create("Frajola", 2, SexOfPet.Male, "Black", b1);
        Assert.True(pet1.Equals(pet2));
    }
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var b1 = BreedId.New();
        var pet1 = Pet.Create("Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = Pet.Create("Frajola", 2, SexOfPet.Male, "Black", b1);
        Assert.True(pet1 == pet2);
    }
    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var b1 = BreedId.New();
        var pet1 =  Pet.Create("Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = Pet.Create("Frajola", 2, SexOfPet.Male, "Black", b1);
        Assert.True(pet1 != pet2);
    }
    [Fact]
    public void Weight_should_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);
        Assert.True(w1 == w2);
    }
    [Fact]
    public void WeightRange_should_be_equal()
    {
        var w1 = new WeightRange(25.5m, 30.0m);
        var w2 = new WeightRange(25.5m, 30.0m);
        Assert.True(w1 == w2);
    }
    [Fact]
    public void BreedId_should_be_Valid()
    {
        var service = new FakeBreedService();
        var id = service.breeds.First().Id;
        var b1 = BreedId.New();
        Assert.NotNull(b1);
    }
    [Fact]
    public void BreedId_should_not_be_Valid()
    {
        var id = Guid.Empty;
        Assert.Throws<ArgumentNullException>(() =>
        {
            var b1 = BreedId.Create(id);
        });
    }
    [Fact]
    public void WeightClass_shold_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = BreedId.New();
        var pet =  Pet.Create("Duque", 2, SexOfPet.Male, "White", breedId);
        pet.SetWeight(10, breedService);
        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }
    [Fact]
    public void WeightClass_shold_be_underweight()
    {
        var breedService = new FakeBreedService();
        var breedId = BreedId.New();
        var pet = Pet.Create("Duque", 2, SexOfPet.Male, "White", breedId);
        pet.SetWeight(4, breedService);
        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }
    [Fact]
    public void WeightClass_shold_be_overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = BreedId.New();
        var pet =  Pet.Create("Duque", 2, SexOfPet.Female, "White", breedId);
        pet.SetWeight(21, breedService);
        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }

}
