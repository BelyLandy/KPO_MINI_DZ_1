using Zoopark_ERP.Animals.Abstractions;
using Zoopark_ERP.Services.Interfaces;

namespace Zoopark_ERP.Services;

/// <summary>
/// Класс ветклиники.
/// </summary>
public class VetClinic : IVetClinic
{

    /// <summary>
    /// Логика проверки здоровья. Заглушка.
    /// </summary>
    /// <param name="animal">Животное.</param>
    /// <returns>True - здоровое. False - обратное</returns>
    public bool CheckAnimalHealth(Animal animal)
    {
        // Пример заглушки для проверки.
        // Животное считается здоровым, если четное.
        return animal.Food % 2 == 0;
    }
}