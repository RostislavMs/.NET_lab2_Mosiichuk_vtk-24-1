using ExtensionMethodsAndGenericsDemo;
using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        var dictionary = new ExtendedDictionary<string, string, int>();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== Головне Меню =====");
            Console.WriteLine("1. Робота з рядком");
            Console.WriteLine("2. Робота з масивами");
            Console.WriteLine("3. Робота з розширеним словником");
            Console.WriteLine("0. Вийти");
            Console.Write("Виберіть категорію: ");

            switch (Console.ReadLine())
            {
                case "1":
                    StringOperationsMenu();
                    break;
                case "2":
                    ArrayOperationsMenu();
                    break;
                case "3":
                    DictionaryOperationsMenu(dictionary);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }
    }

    static void StringOperationsMenu()
    {
        Console.Clear();
        Console.WriteLine("===== Робота з рядком =====");
        Console.Write("Введіть рядок: ");
        string inputString = Console.ReadLine();

        Console.WriteLine("1. Інвертувати рядок");
        Console.WriteLine("2. Порахувати кількість входжень символа");
        Console.Write("Виберіть дію: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine($"Інвертований рядок: {inputString.Reverse()}");
                break;
            case "2":
                Console.Write("Введіть символ для підрахунку: ");
                char character = Console.ReadLine()[0];
                Console.WriteLine($"Кількість входжень '{character}': {inputString.CountOccurrences(character)}");
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static void ArrayOperationsMenu()
    {
        Console.Clear();
        Console.WriteLine("===== Робота з масивом =====");
        int[] numbers = GetIntArrayFromUser();

        Console.WriteLine("1. Порахувати кількість входжень значення");
        Console.WriteLine("2. Отримати унікальні елементи масиву");
        Console.Write("Виберіть дію: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Введіть значення для підрахунку: ");
                int value = int.Parse(Console.ReadLine());
                Console.WriteLine($"Кількість входжень значення {value}: {numbers.CountOccurrences(value)}");
                break;
            case "2":
                var uniqueNumbers = numbers.GetUniqueElements();
                Console.WriteLine("Унікальні елементи масиву: " + string.Join(", ", uniqueNumbers));
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static void DictionaryOperationsMenu(ExtendedDictionary<string, string, int> dictionary)
    {
        Console.Clear();
        Console.WriteLine("===== Робота з розширеним словником =====");
        Console.WriteLine("1. Додати елемент");
        Console.WriteLine("2. Видалити елемент за ключем");
        Console.WriteLine("3. Перевірити наявність ключа");
        Console.WriteLine("4. Перевірити наявність значення");
        Console.WriteLine("5. Отримати елемент за ключем");
        Console.WriteLine("6. Показати всі елементи словника");
        Console.WriteLine("7. Кількість елементів у словнику");
        Console.Write("Виберіть дію: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Введіть ключ (string): ");
                string key = Console.ReadLine();
                Console.Write("Введіть перше значення (string): ");
                string value1 = Console.ReadLine();
                Console.Write("Введіть друге значення (int): ");
                int value2 = int.Parse(Console.ReadLine());
                dictionary.Add(key, value1, value2);
                Console.WriteLine("Елемент додано до словника.");
                break;
            case "2":
                Console.Write("Введіть ключ для видалення: ");
                key = Console.ReadLine();
                if (dictionary.Remove(key))
                    Console.WriteLine("Елемент видалено.");
                else
                    Console.WriteLine("Ключ не знайдено.");
                break;
            case "3":
                Console.Write("Введіть ключ для перевірки: ");
                key = Console.ReadLine();
                Console.WriteLine(dictionary.ContainsKey(key) ? "Ключ знайдено." : "Ключ не знайдено.");
                break;
            case "4":
                Console.Write("Введіть перше значення: ");
                value1 = Console.ReadLine();
                Console.Write("Введіть друге значення (int): ");
                value2 = int.Parse(Console.ReadLine());
                Console.WriteLine(dictionary.ContainsValue(value1, value2) ? "Значення знайдено." : "Значення не знайдено.");
                break;
            case "5":
                Console.Write("Введіть ключ для отримання елемента: ");
                key = Console.ReadLine();
                var element = dictionary[key];
                if (element != null)
                    Console.WriteLine($"Елемент: Key={element.Key}, Value1={element.Value1}, Value2={element.Value2}");
                else
                    Console.WriteLine("Елемент не знайдено.");
                break;
            case "6":
                Console.WriteLine("Всі елементи словника:");
                foreach (var elem in dictionary)
                    Console.WriteLine($"Key={elem.Key}, Value1={elem.Value1}, Value2={elem.Value2}");
                break;
            case "7":
                Console.WriteLine($"Кількість елементів у словнику: {dictionary.Count}");
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static int[] GetIntArrayFromUser()
    {
        Console.Write("Введіть елементи масиву через кому: ");
        string input = Console.ReadLine();
        string[] parts = input.Split(',');
        int[] numbers = new int[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            numbers[i] = int.Parse(parts[i].Trim());
        }

        return numbers;
    }
}
