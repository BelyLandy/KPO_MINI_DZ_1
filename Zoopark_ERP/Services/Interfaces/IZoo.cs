using Zoopark_ERP.Animals.Abstractions;
using Zoopark_ERP.Things.Interfaces;

namespace Zoopark_ERP.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для класса Zoo, предоставляющий методы для управления животными и инвентарем.
    /// </summary>
    public interface IZoo
    {
        /// <summary>
        /// Добавляет животное в зоопарк, предварительно проверяя его здоровье.
        /// </summary>
        /// <param name="animal">Животное для добавления.</param>
        /// <returns>True, если животное прошло проверку и было добавлено; иначе false.</returns>
        bool AddAnimal(Animal animal);

        /// <summary>
        /// Добавляет объект, реализующий IInventory, в инвентарь зоопарка.
        /// </summary>
        /// <param name="thing">Объект, реализующий IInventory.</param>
        void AddThing(IInventory thing);

        /// <summary>
        /// Возвращает общее количество животных в зоопарке.
        /// </summary>
        /// <returns>Количество животных.</returns>
        int TotalAnimalsCount();

        /// <summary>
        /// Возвращает общее количество еды, потребляемой всеми животными.
        /// </summary>
        /// <returns>Суммарное количество еды.</returns>
        int TotalFoodRequired();

        /// <summary>
        /// Возвращает животных, которые подходят для контактного зоопарка.
        /// </summary>
        /// <returns>Перечисление животных, подходящих для контактного зоопарка.</returns>
        IEnumerable<Animal> GetContactZooAnimals();

        /// <summary>
        /// Возвращает список инвентарных объектов с их наименованиями и номерами.
        /// </summary>
        /// <returns>Перечисление кортежей с именем и номером каждого объекта.</returns>
        IEnumerable<(string Name, int Number)> GetInventoryItems();

        /// <summary>
        /// Возвращает все объекты инвентаря зоопарка.
        /// </summary>
        /// <returns>Перечисление объектов, реализующих IInventory.</returns>
        IEnumerable<IInventory> GetInventoryObjects();
    }
}
