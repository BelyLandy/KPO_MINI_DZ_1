using Zoopark_ERP.Animals.Abstractions;

namespace Zoopark_ERP.Animals;

/// <summary>
/// Класс хищного тигра.
/// </summary>
public class Tiger : Predator
{
    public Tiger(string name, int food, int number)
        : base(name, food, number)
    {
    }
}