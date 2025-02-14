using Zoopark_ERP.Animals;

namespace Zoopark_Tests;

public class AnimalTests
{
    [Fact]
    public void Rabbit_Constructor_SetsProperties()
    {
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        Assert.Equal("Кролик", rabbit.Name);
        Assert.Equal(4, rabbit.Food);
        Assert.Equal(101, rabbit.Number);
        Assert.Equal(7, rabbit.KindnessLevel);
    }

    [Fact]
    public void Wolf_Constructor_SetsProperties()
    {
        var wolf = new Wolf("Волк", 6, 102);
        Assert.Equal("Волк", wolf.Name);
        Assert.Equal(6, wolf.Food);
        Assert.Equal(102, wolf.Number);
    }

    [Fact]
    public void Monkey_Constructor_SetsProperties()
    {
        var monkey = new Monkey("Макака", 8, 103, 9);
        Assert.Equal("Макака", monkey.Name);
        Assert.Equal(8, monkey.Food);
        Assert.Equal(103, monkey.Number);
        Assert.Equal(9, monkey.KindnessLevel);
    }

    [Fact]
    public void Tiger_Constructor_SetsProperties()
    {
        var tiger = new Tiger("Тигр", 10, 104);
        Assert.Equal("Тигр", tiger.Name);
        Assert.Equal(10, tiger.Food);
        Assert.Equal(104, tiger.Number);
    }

    [Fact]
    public void Herbo_CanBeContacted_ReturnsTrue_WhenKindnessGreaterThanFive()
    {
        // Для травоядных животных, если уровень доброты > 5, они пригодны для контактного зоопарка.
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        Assert.True(rabbit.CanBeContacted);
    }

    [Fact]
    public void Herbo_CanBeContacted_ReturnsFalse_WhenKindnessFiveOrLess()
    {
        var monkey = new Monkey("Макака", 8, 102, 5);
        Assert.False(monkey.CanBeContacted);
    }
}