using Zoopark_ERP.Things.Abstractions;

namespace Zoopark_ERP.Things;

/// <summary>
/// Класс стола.
/// </summary>
public class Table : Thing
{
    public Table(string name, int number)
        : base(name, number)
    {
    }
}