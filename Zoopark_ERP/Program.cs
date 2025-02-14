using Microsoft.Extensions.DependencyInjection;
using Zoopark_ERP.Services;
using Zoopark_ERP.Services.Interfaces;
using Zoopark_ERP.Things;
using Zoopark_ERP.UI;

namespace Zoopark_ERP;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Создаем коллекцию сервисов для DI-контейнера.
            var services = new ServiceCollection();
            // Настраиваем зависимости.
            ConfigureServices(services);
            // Создаем провайдер сервисов.
            var serviceProvider = services.BuildServiceProvider();

            // Получаем экземпляр зоопарка из DI-контейнера.
            var zoo = serviceProvider.GetService<Zoo>();

            // Заполняем инвентарь зоопарка дополнительными вещами.
            zoo.AddThing(new Table("Столовая группа", 1001));
            zoo.AddThing(new Computer("Рабочий компьютер", 1002));

            // Запускаем пользовательский интерфейс, передавая экземпляр зоопарка.
            var ui = new ConsoleUI(zoo);
            ui.Run();
        }
        catch (Exception ex)
        {
            // Обработка непредвиденных ошибок на уровне приложения.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nПроизошла непредвиденная ошибка: " + ex.Message);
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Настраивает DI-контейнер, регистрируя необходимые зависимости.
    /// </summary>
    /// <param name="services">Коллекция сервисов для регистрации зависимостей.</param>
    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<IVetClinic, VetClinic>();
        services.AddSingleton<Zoo>();
    }
}