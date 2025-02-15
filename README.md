# КПО. Мини-дз №1

## Работу выполнил Девятов Денис Сергеевич БПИ-238.

## Описание проекта

Консольное приложение для автоматизации учёта животных Московского зоопарка и инвентаризации имущества предприятия. Система обеспечивает:

- **Приём животных:** При добавлении нового животного происходит проверка его состояния здоровья через службу ветеринарной клиники.
- **Подсчёт расхода еды:** Вычисляется общее количество килограммов еды, потребляемое всеми животными за сутки.
- **Формирование списка для контактного зоопарка:** Отбираются травоядные животные с уровнем доброты выше 5, что позволяет организовывать интерактивное взаимодействие с посетителями.
- **Инвентаризация:** Ведётся учёт животных и вещей (например, столов, компьютеров) с их инвентарными номерами.

## Архитектура и принципы решения

### Структура проекта

Проект разделён на несколько модулей для обеспечения чистоты и расширяемости кода:

- **Animals**  
  - **Abstractions:**  
    Базовые классы `Animal`, `Herbo` и `Predator`, которые описывают общие свойства и поведение животных.
  - **Interfaces:**  
    Интерфейс `IAlive` для объектов, относящихся к категории «живых».
  - **Реализации:**  
    Конкретные классы животных: `Monkey`, `Rabbit`, `Tiger`, `Wolf`.

- **Things**  
  - **Abstractions:**  
    Базовый класс `Thing` для объектов инвентаризации.
  - **Interfaces:**  
    Интерфейс `IInventory` для инвентарных объектов.
  - **Реализации:**  
    Примеры объектов: `Table`, `Computer`.

- **Services**  
  Модуль, содержащий бизнес-логику:
  - **Ветеринарная клиника:**  
    Интерфейс `IVetClinic` и его реализация `VetClinic` для проверки здоровья животных.
  - **Зоопарк:**  
    Interface` IZoo` и класс `Zoo`, управляющий списками животных и инвентарных объектов, подсчётом еды и формированием списков для контактного зоопарка.

### Принципы SOLID

- **SRP (Единственная ответственность):**  
  Каждый класс имеет чётко определённую задачу. Например, `Zoo` отвечает за управление коллекциями, а `VetClinic` — только за проверку здоровья животных.

- **OCP (Открытость/закрытость):**  
  Добавление новых типов животных или вещей реализуется через наследование от базовых классов, без изменения уже существующего кода.

- **LSP (Подстановка Лисков):**  
  Все наследники `Animal` могут использоваться в методах класса `Zoo`, что обеспечивает корректное поведение при расширении функциональности.

- **ISP (Разделение интерфейсов):**  
  Интерфейсы `IAlive` и `IInventory` предоставляют только необходимые свойства для соответствующих категорий объектов.

- **DIP (Инверсия зависимостей):**  
  Класс `Zoo` зависит от абстракции `IVetClinic`, что упрощает замену реализации проверки здоровья. DI-контейнер (Microsoft.Extensions.DependencyInjection) используется для внедрения зависимостей.

### Тестирование

Для обеспечения надёжности и корректности работы приложения реализованы модульные тесты, покрывающие ключевые аспекты бизнес-логики:
- **Тесты для животных:** Проверка корректной инициализации свойств и логики определения пригодности для контактного зоопарка.
- **Тесты для инвентарных объектов:** Проверка установки свойств для объектов типа `Table` и `Computer`.
- **Тесты для ветклиники:** Валидация метода проверки здоровья животных, где животное считается здоровым, если количество потребляемой еды — чётное.
- **Тесты для зоопарка:** Проверка добавления животных, подсчёта общего количества еды, формирования списка для контактного зоопарка и инвентаризации.

Тесты позволяют достичь высокого уровня покрытия (более 60%) и гарантируют стабильность функционала при внесении изменений.

### Установка xUnit

Для тестирования используется xUnit. Тесты покрывают логику проверки здоровья животных, добавления их в зоопарк и другие ключевые моменты.

```bash
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package coverlet.collector
```

## Инструкция по запуску

1. **Установка .NET SDK**  
   Убедитесь, что у вас установлен .NET SDK версии 5.0 или выше. Скачать его можно с [официального сайта .NET](https://dotnet.microsoft.com/download).

2. **Клонирование репозитория**  
   Склонируйте проект:
   ```bash
   git clone <URL вашего репозитория>
   ```

3. **Сборка и запуск приложения**  
   Перейдите в корневую директорию проекта и выполните команды:
   ```bash
   dotnet build
   dotnet run
   ```

4. **Запуск тестов**  
   Для запуска модульных тестов используйте команду:
   ```bash
   dotnet test
   ```
