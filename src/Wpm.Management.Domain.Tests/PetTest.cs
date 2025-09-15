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
        var b1 = new BreedId(service.breeds[0].Id, service);
        var pet1 = new Pet(id, "Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = new Pet(id, "Frajola", 2, SexOfPet.Male, "Black", b1);
        Assert.True(pet1.Equals(pet2));
    }
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var service = new FakeBreedService();
        var idBread = service.breeds.First().Id;
        var b1 = new BreedId(idBread, service);
        var pet1 = new Pet(id, "Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = new Pet(id, "Frajola", 2, SexOfPet.Male, "Black", b1);
        Assert.True(pet1 == pet2);
    }
    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var firstId = Guid.NewGuid();
        var secondId = Guid.NewGuid();
        var service = new FakeBreedService();
        var id = service.breeds.First().Id;
        var b1 = new BreedId(id, service);
        var pet1 = new Pet(firstId, "Duque", 2, SexOfPet.Male, "White", b1);
        var pet2 = new Pet(secondId, "Frajola", 2, SexOfPet.Male, "Black", b1);
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
        var b1 = new BreedId(id, service);
        Assert.NotNull(b1);
    }
    [Fact]
    public void BreedId_should_not_be_Valid()
    {
        var service = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentNullException>(() =>
        {
            var b1 = new BreedId(id, service);
        });
    }
    [Fact]
    public void WeightClass_shold_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Duque", 2, SexOfPet.Male, "White", breedId);
        pet.SetWeight(10, breedService);
        Assert.True(pet.WeightClass == WeihgtClass.Ideal);
    }
    [Fact]
    public void WeightClass_shold_be_underweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Duque", 2, SexOfPet.Male, "White", breedId);
        pet.SetWeight(4, breedService);
        Assert.True(pet.WeightClass == WeihgtClass.Underweight);
    }
    [Fact]
    public void WeightClass_shold_be_overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Duque", 2, SexOfPet.Female, "White", breedId);
        pet.SetWeight(21, breedService);
        Assert.True(pet.WeightClass == WeihgtClass.Overweight);
    }

}
