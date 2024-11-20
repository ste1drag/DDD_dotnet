using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_Should_Be_Equal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet1 = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        Pet pet2 = new Pet(id, "Nina", 10, "Three-color", SexOfPet.Male, breedId);

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_Should_Be_Equal_Using_Operators()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet1 = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        Pet pet2 = new Pet(id, "Nina", 10, "Three-color", SexOfPet.Male, breedId);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_Should_Not_Be_Equal_Using_Operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet1 = new Pet(id1, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);
        Pet pet2 = new Pet(id2, "Nina", 10, "Three-color", SexOfPet.Male, breedId);

        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_Should_Be_Equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);

        Assert.True(w1 == w2);
    }

    [Fact]
    public void WeightRange_Should_Be_Equal()
    {
        var wr1 = new WeightRange(10.5m, 20.5m);
        var wr2 = new WeightRange(10.5m, 20.5m);

        Assert.True(wr1.Equals(wr2));
    }

    [Fact]
    public void BreedId_Should_Be_Valid()
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_Should_Not_Be_Valid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentException>(() =>
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_Should_Be_Ideal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);

        pet.SetWeight(10, breedService);

        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_Should_Be_Overweight()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);

        pet.SetWeight(breedService.breeds[0].MaleIdealWeight.To + 1, breedService);

        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }

    [Fact]
    public void WeightClass_Should_Be_Underweight()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        Pet pet = new Pet(id, "Gianni", 13, "Three-color", SexOfPet.Male, breedId);

        pet.SetWeight(breedService.breeds[0].MaleIdealWeight.From - 1, breedService);

        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }
}