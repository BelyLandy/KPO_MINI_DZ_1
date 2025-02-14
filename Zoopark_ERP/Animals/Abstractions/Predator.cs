namespace Zoopark_ERP.Animals.Abstractions;

/// <summary>
/// Класс хищных животных.
/// </summary>
public abstract class Predator : Animal
{
    protected Predator(string name, int food, int number)
        : base(name, food, number)
    {
    }
}