namespace Zoopark_ERP.Animals.Abstractions;

/// <summary>
/// Класс травоядных животных.
/// </summary>
public abstract class Herbo : Animal
{
    public int KindnessLevel { get; set; }
    public bool CanBeContacted => KindnessLevel > 5;

    protected Herbo(string name, int food, int number, int kindnessLevel)
        : base(name, food, number)
    {
        KindnessLevel = kindnessLevel;
    }
}