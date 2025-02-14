using Zoopark_ERP.Animals;
using Zoopark_ERP.Animals.Abstractions;
using Zoopark_ERP.Services;
using Zoopark_ERP.Things.Abstractions;

namespace Zoopark_ERP.UI;

/// <summary>
/// Вспомогательный класс для вывода данных в консоль.
/// Отвечает за взаимодействие с пользователем, вывод меню и обработку ввода.
/// </summary>
public class ConsoleUI
{
    private readonly Zoo _zoo; // Экземпляр зоопарка для работы с животными и инвентарем.

    // Конструктор, принимающий экземпляр зоопарка через внедрение зависимости (DI).
    public ConsoleUI(Zoo zoo)
    {
        _zoo = zoo;
    }

    /// <summary>
    /// Основной метод запуска пользовательского интерфейса.
    /// Организует цикл работы программы с отображением меню.
    /// </summary>
    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            // Очищаем консоль и выводим главное меню.
            Console.Clear();
            PrintMainMenu();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ваш выбор -> ");
            Console.ResetColor();
            
            string choice = Console.ReadLine()?.Trim();

            // Обработка ввода пользователя согласно выбранной опции.
            switch (choice)
            {
                case "0":
                    exit = true; // Завершаем работу приложения.
                    break;
                
                case "1":
                    Console.Clear();
                    AddAnimal(); // Переходим к добавлению нового животного.
                    ReturnToMainMenu();
                    break;
                
                case "2":
                    Console.Clear();
                    ReportAnimals(); // Вывод отчёта по животным.
                    ReturnToMainMenu();
                    break;
                
                case "3":
                    Console.Clear();
                    ContactZooReport(); // Отображение списка животных для контактного зоопарка.
                    ReturnToMainMenu();
                    break;
                
                case "4":
                    Console.Clear();
                    InventoryReport(); // Вывод информации по инвентарю зоопарка.
                    ReturnToMainMenu();
                    break;
                
                default:
                    // Если введён неверный вариант, сообщаем об ошибке и ждём нажатия Enter.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНеверный выбор, попробуйте снова.\n");
                    Console.ResetColor();
                    WaitForUserInput();
                    break;
                
            }
        }
    }

    /// <summary>
    /// Вывод главного меню в консоль.
    /// </summary>
    private void PrintMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Главное меню ===\n");
        Console.WriteLine("1. Добавить животное.");
        Console.WriteLine("2. Отчет по животным.");
        Console.WriteLine("3. Список животных для контактного зоопарка.");
        Console.WriteLine("4. Краткая информация обо всем инвентаре зоопарка.");
        Console.WriteLine("0. Выход.");
        Console.WriteLine("Введите 'back' в любом месте программы, чтобы вернуться сюда.");
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Ожидает нажатия клавиши Enter и очищает консоль, возвращая пользователя в главное меню.
    /// </summary>
    private void ReturnToMainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ResetColor();
        Console.ReadLine();
    }

    /// <summary>
    /// Ждет ввода от пользователя, затем продолжает работу.
    /// </summary>
    private void WaitForUserInput()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nНажмите Enter для продолжения...");
        Console.ResetColor();
        Console.ReadLine();
    }

    /// <summary>
    /// Запрашивает строковый ввод у пользователя. 
    /// Если введено "back", метод возвращает null.
    /// </summary>
    /// <param name="prompt">Сообщение для пользователя.</param>
    /// <returns>Введенная строка или null, если введено "back".</returns>
    private string GetInputWithBackOption(string prompt)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prompt);
            Console.ResetColor();
            
            string input = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                // Если введена пустая строка, сообщаем об ошибке и повторяем запрос.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод, попробуйте снова.\n");
                Console.ResetColor();
                
                continue;
            }

            if (input.ToLower() == "back")
                return null;
            return input;
        }
    }

    /// <summary>
    /// Запрашивает целочисленный ввод у пользователя. 
    /// Если введено "back", метод возвращает null.
    /// При неверном формате ввода повторяет запрос.
    /// </summary>
    /// <param name="prompt">Сообщение для пользователя.</param>
    /// <returns>Введенное число или null, если введено "back".</returns>
    private int? GetIntInput(string prompt)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prompt);
            Console.ResetColor();
            
            string input = Console.ReadLine()?.Trim();
            
            if (input.ToLower() == "back")
                return null;
            
            if (int.TryParse(input, out int value))
                return value;
            
            // Если ввод не является числом, сообщаем об ошибке.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некорректный ввод, попробуйте снова.\n");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Метод для добавления нового животного в зоопарк.
    /// Обрабатывает выбор типа животного, запрашивает необходимые данные и добавляет его через _zoo.
    /// </summary>
    private void AddAnimal()
    {
        try
        {
            string type = null;
            string typeChoice = null;

            // Меню выбора типа животного.
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== Выберите тип животного ===\n");
                Console.WriteLine("1 - Обезьяна.");
                Console.WriteLine("2 - Кролик.");
                Console.WriteLine("3 - Тигр.");
                Console.WriteLine("4 - Волк.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВаш выбор -> ");
                Console.ResetColor();
                typeChoice = Console.ReadLine()?.Trim();

                if (typeChoice?.ToLower() == "back")
                    return;

                // Проверяем корректность выбора.
                if (typeChoice == "1" || typeChoice == "2" || typeChoice == "3" || typeChoice == "4")
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор, попробуйте снова.\n");
                    Console.ResetColor();
                }
            }

            // Определяем тип животного по выбору.
            switch (typeChoice)
            {
                case "1":
                    type = "monkey";
                    break;
                
                case "2":
                    type = "rabbit";
                    break;
                
                case "3":
                    type = "tiger";
                    break;
                
                case "4":
                    type = "wolf";
                    break;
                
            }

            // Запрашиваем у пользователя инвентаризационный номер, имя и количество потребляемой еды
            int? number = GetIntInput("Введите инвентаризационный номер: ");
            if (number == null) return;

            string name = GetInputWithBackOption("Введите название: ");
            if (name == null) return;

            int? food = GetIntInput("Введите количество потребляемой еды (кг): ");
            if (food == null) return;

            Animal animal = null;
            // Если выбран тип с дополнительным параметром (добротой) – кролик или обезьяна
            if (type == "rabbit" || type == "monkey")
            {
                int? kindness = null;
                
                while (true)
                {
                    kindness = GetIntInput("Введите уровень доброты (0-10): ");
                    if (kindness == null)
                        return;
                    
                    // Проверка, что уровень доброты в допустимом диапазоне
                    if (kindness.Value >= 0 && kindness.Value <= 10)
                        break;
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Уровень доброты должен быть в диапазоне от 0 до 10. Попробуйте снова.\n");
                    Console.ResetColor();
                }

                // Создаем экземпляр животного в зависимости от выбора.
                animal = type == "rabbit"
                    ? new Rabbit(name, food.Value, number.Value, kindness.Value)
                    : new Monkey(name, food.Value, number.Value, kindness.Value);
            }
            else if (type == "tiger")
            {
                animal = new Tiger(name, food.Value, number.Value);
            }
            else if (type == "wolf")
            {
                animal = new Wolf(name, food.Value, number.Value);
            }

            // Добавляем животное в зоопарк; метод AddAnimal также проводит проверку здоровья.
            bool isHealthy = _zoo.AddAnimal(animal);
            if (isHealthy)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nЖивотное успешно добавлено в зоопарк.");
                Console.WriteLine("(Проверка здоровья: здоров)\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЖивотное не прошло проверку здоровья.");
                Console.WriteLine("(Проверка здоровья: не здоров)\n");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            // Обработка исключений при добавлении животного.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nОшибка при добавлении животного: " + ex.Message + "\n");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Формирует и выводит отчёт по животным зоопарка.
    /// Отображает общее количество животных и суммарное количество потребляемой еды.
    /// </summary>
    private void ReportAnimals()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Отчет по животным ===\n");
            Console.WriteLine($"Количество животных: {_zoo.TotalAnimalsCount()}\n");
            Console.WriteLine($"Общее количество потребляемой еды: {_zoo.TotalFoodRequired()} кг\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Обработка ошибок при формировании отчёта.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка при формировании отчёта: " + ex.Message + "\n");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Формирует и выводит список животных, подходящих для контактного зоопарка.
    /// Если подходящих животных нет, выводится сообщение об этом.
    /// </summary>
    private void ContactZooReport()
    {
        try
        {
            var contactAnimals = _zoo.GetContactZooAnimals();
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (!contactAnimals.Any())
            {
                // Если список пуст, сообщаем об отсутствии данных
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n=== Животные для контактного зоопарка отсутствуют! ===\n");
                Console.ResetColor();
                
                return;
            }

            Console.WriteLine("\n=== Животные для контактного зоопарка ===\n");
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine($"Имя: {animal.Name}\nИнвентарный номер: {animal.Number}\n");
            }

            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Обработка ошибок при формировании отчёта
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка при формировании списка животных для контактного зоопарка: " + ex.Message + "\n");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Выводит подробную информацию обо всем инвентаре зоопарка.
    /// Для животных отображаются: тип, название, инвентарный номер, потребляемая еда и (если применимо) уровень доброты.
    /// Для остальных объектов – тип, название и инвентарный номер.
    /// Если значение отсутствует или равно 0, выводится прочерк ("-").
    /// </summary>
    private void InventoryReport()
    {
        try
        {
            var inventoryItems = _zoo.GetInventoryObjects();
            if (!inventoryItems.Any())
            {
                // Если инвентарь пуст, выводим сообщение
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=== Баланс зоопарка отсутствует! ===\n");
                Console.ResetColor();
                
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Баланс зоопарка ===\n");
            
            foreach (var item in inventoryItems)
            {
                if (item is Animal animal)
                {
                    // Форматирование данных животного для вывода
                    string name = FormatValue(animal.Name);
                    string number = FormatValue(animal.Number);
                    string food = FormatValue(animal.Food);

                    Console.WriteLine("Тип: Животное");
                    Console.WriteLine($"Название: {name}");
                    Console.WriteLine($"Инвентарный номер: {number}");
                    Console.WriteLine($"Потребляемая еда (кг): {food}");

                    // Если животное относится к травоядным, дополнительно выводим уровень доброты
                    if (animal is Herbo herbo)
                    {
                        string kindness = FormatValue(herbo.KindnessLevel);
                        Console.WriteLine($"Уровень доброты: {kindness}");
                    }
                }
                else if (item is Thing thing)
                {
                    // Форматирование данных для объектов типа Thing
                    string name = FormatValue(thing.Name);
                    string number = FormatValue(thing.Number);
                    Console.WriteLine("Тип: Вещь");
                    Console.WriteLine($"Название: {name}");
                    Console.WriteLine($"Инвентарный номер: {number}");
                }
                else
                {
                    // Если тип объекта неизвестен, выводим сообщение
                    Console.WriteLine("Тип: Неизвестно");
                }

                // Вывод разделительной линии для удобства чтения отчёта
                Console.WriteLine(new string('-', 40));
            }

            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Обработка ошибок при выводе инвентарного отчёта
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка при выводе инвентаря: " + ex.Message + "\n");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Форматирует строковое значение для вывода.
    /// Если значение пустое или null, возвращает прочерк.
    /// </summary>
    private string FormatValue(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? "-" : value;
    }

    /// <summary>
    /// Форматирует числовое значение для вывода.
    /// Если значение равно 0, возвращает прочерк.
    /// </summary>
    private string FormatValue(int value)
    {
        return value == 0 ? "-" : value.ToString();
    }
}
