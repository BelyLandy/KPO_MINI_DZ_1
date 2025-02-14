using Zoopark_ERP.Animals.Interfaces;
using Zoopark_ERP.Things.Interfaces;

namespace Zoopark_ERP.Animals.Abstractions;

/// <summary>
/// Класс животных.
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }

    protected Animal(string name, int food, int number)
    {
        Name = name;
        Food = food;
        Number = number;
    }
}