using Zoopark_ERP.Animals;
using Zoopark_ERP.Services;

namespace Zoopark_Tests;

public class VetClinicTests
{
    [Fact]
    public void CheckAnimalHealth_EvenFood_ReturnsTrue()
    {
        // Животное со значением Food = 4 (четное) считается здоровым.
        var vetClinic = new VetClinic();
        var rabbit = new Rabbit("Кролик", 4, 101, 7);
        bool isHealthy = vetClinic.CheckAnimalHealth(rabbit);
        Assert.True(isHealthy);
    }

    [Fact]
    public void CheckAnimalHealth_OddFood_ReturnsFalse()
    {
        // Животное со значением Food = 7 (нечетное) считается нездоровым.
        var vetClinic = new VetClinic();
        var monkey = new Monkey("Макака", 7, 102, 9);
        bool isHealthy = vetClinic.CheckAnimalHealth(monkey);
        Assert.False(isHealthy);
    }

    [Fact]
    public void CheckAnimalHealth_TigerEvenFood_ReturnsTrue()
    {
        var vetClinic = new VetClinic();
        var tiger = new Tiger("Тигр", 8, 105);
        bool isHealthy = vetClinic.CheckAnimalHealth(tiger);
        Assert.True(isHealthy);
    }
}