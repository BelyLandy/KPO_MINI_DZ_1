using Zoopark_ERP.Animals.Abstractions;
using Zoopark_ERP.Services.Interfaces;
using Zoopark_ERP.Things.Abstractions;
using Zoopark_ERP.Things.Interfaces;

namespace Zoopark_ERP.Services
{
    public class Zoo
    {
        private readonly List<Animal> animals;
        private readonly List<IInventory> inventory;
        private readonly IVetClinic vetClinic;

        public Zoo(IVetClinic vetClinic)
        {
            animals = new List<Animal>();
            inventory = new List<IInventory>();
            this.vetClinic = vetClinic;
        }

        public bool AddAnimal(Animal animal)
        {
            // Перед добавлением проверяем состояние здоровья
            if (vetClinic.CheckAnimalHealth(animal))
            {
                animals.Add(animal);
                inventory.Add(animal);
                return true;
            }
            return false;
        }

        public void AddThing(IInventory thing)
        {
            inventory.Add(thing);
        }

        public int TotalAnimalsCount() => animals.Count;

        public int TotalFoodRequired() => animals.Sum(a => a.Food);

        // Возвращает животных, которые подходят для контактного зоопарка
        public IEnumerable<Animal> GetContactZooAnimals()
        {
            return animals.OfType<Herbo>().Where(h => h.CanBeContacted);
        }

        // Возвращает список инвентарных объектов с наименованиями и номерами
        public IEnumerable<(string Name, int Number)> GetInventoryItems()
        {
            return inventory.Select(item =>
            {
                if (item is Animal animal)
                    return (animal.Name, animal.Number);
                else if (item is Thing thing)
                    return (thing.Name, thing.Number);
                else
                    return ("Unknown", item.Number);
            });
        }
        
        // Новый метод для получения всех объектов инвентаря
        public IEnumerable<IInventory> GetInventoryObjects()
        {
            return inventory;
        }
    }
}