using Zoopark_ERP.Animals;
using Zoopark_ERP.Things;
using Zoopark_ERP.Services;

namespace Zoopark_Tests;

public class ZooTests
{
    [Fact]
    public void AddAnimal_HealthyAnimal_IncreasesAnimalCount()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        // Здоровое животное. Food = 4 (четное).
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        bool added = zoo.AddAnimal(rabbit);
        Assert.True(added);
        Assert.Equal(1, zoo.TotalAnimalsCount());
    }

    [Fact]
    public void AddAnimal_UnhealthyAnimal_DoesNotIncreaseAnimalCount()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        // Нездоровое животное. Food = 5 (нечетное).
        var wolf = new Wolf("Волк", 5, 102);
        bool added = zoo.AddAnimal(wolf);
        Assert.False(added);
        Assert.Equal(0, zoo.TotalAnimalsCount());
    }

    [Fact]
    public void TotalFoodRequired_ReturnsCorrectSum()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        // Добавляем два здоровых животного 4 + 8 = 12.
        var rabbit = new Rabbit("Кролик", 4, 101, 6);
        var monkey = new Monkey("Макака", 8, 102, 7);
        zoo.AddAnimal(rabbit);
        zoo.AddAnimal(monkey);
        int totalFood = zoo.TotalFoodRequired();
        Assert.Equal(12, totalFood);
    }

    [Fact]
    public void GetContactZooAnimals_ReturnsOnlyEligibleAnimals()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        // Травоядное с уровнем доброты > 5.
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        // Это животное имеет доброту 5, значит не подходит.
        var monkey = new Monkey("Макака", 8, 102, 5);
        // Хищник не учитывается для контактного зоопарка.
        var tiger = new Tiger("Тигр", 10, 103);

        zoo.AddAnimal(rabbit);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(tiger);

        var contactAnimals = zoo.GetContactZooAnimals().ToList();
        // Ожидается, что только rabbit попадёт в список.
        Assert.Single(contactAnimals);
        Assert.Equal("Кролик", contactAnimals[0].Name);
    }

    [Fact]
    public void GetInventoryItems_ReturnsCorrectTuples()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        var table = new Table("Стол", 201);

        zoo.AddAnimal(rabbit);
        zoo.AddThing(table);

        var inventoryItems = zoo.GetInventoryItems().ToList();
        Assert.Equal(2, inventoryItems.Count);

        var animalItem = inventoryItems.FirstOrDefault(i => i.Name == "Кролик");
        Assert.NotNull(animalItem);
        Assert.Equal(101, animalItem.Number);

        var thingItem = inventoryItems.FirstOrDefault(i => i.Name == "Стол");
        Assert.NotNull(thingItem);
        Assert.Equal(201, thingItem.Number);
    }

    [Fact]
    public void AddThing_IncreasesInventoryCount()
    {
        var vetClinic = new VetClinic();
        var zoo = new Zoo(vetClinic);
        int initialCount = zoo.GetInventoryObjects().Count();
        zoo.AddThing(new Computer("Компьютер", 202));
        int newCount = zoo.GetInventoryObjects().Count();
        Assert.Equal(initialCount + 1, newCount);
    }
}