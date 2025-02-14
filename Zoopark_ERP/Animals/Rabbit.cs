using Zoopark_ERP.Animals.Abstractions;

namespace Zoopark_ERP.Animals;

/// <summary>
/// Класс травоядного кролика.
/// </summary>
public class Rabbit : Herbo
{
    public Rabbit(string name, int food, int number, int kindness)
        : base(name, food, number, kindness)
    {
    }
}