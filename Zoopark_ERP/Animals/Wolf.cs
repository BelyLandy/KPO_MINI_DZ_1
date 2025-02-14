using Zoopark_ERP.Animals.Abstractions;

namespace Zoopark_ERP.Animals;

/// <summary>
/// Класс хищного волка.
/// </summary>
public class Wolf : Predator
{
    public Wolf(string name, int food, int number)
        : base(name, food, number)
    {
    }
}