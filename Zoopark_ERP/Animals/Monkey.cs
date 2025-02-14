using Zoopark_ERP.Animals.Abstractions;

namespace Zoopark_ERP.Animals;

/// <summary>
/// Класс травоядной обезьяны.
/// </summary>
public class Monkey : Herbo
{
    public Monkey(string name, int food, int number, int kindness)
        : base(name, food, number, kindness)
    {
    }
}