using Zoopark_ERP.Animals.Abstractions;

namespace Zoopark_ERP.Services.Interfaces;

/// <summary>
/// Интерфейс, описывающий работу ветклиники.
/// </summary>
public interface IVetClinic
{
    /// <summary>
    /// Проверка здоровое животное, или нет.
    /// Возвращает true, если животное здоровое, и false, если обратное.
    /// </summary>
    /// <param name="animal">Животное.</param>
    /// <returns></returns>
    bool CheckAnimalHealth(Animal animal);
}