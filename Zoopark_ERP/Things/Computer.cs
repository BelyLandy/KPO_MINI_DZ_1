using Zoopark_ERP.Things.Abstractions;

namespace Zoopark_ERP.Things;

/// <summary>
/// Класс компьютера.
/// </summary>
public class Computer : Thing
{
    public Computer(string name, int number)
        : base(name, number)
    {
    }
}