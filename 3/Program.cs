using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] A = { "helloC", "world", "testC", "sample", "HELLOC", "TESTc" };

        while (true) // Безкінечний цикл для введення символу
        {
            try
            {
                Console.Write("\nВведіть символ C (або натисніть ESC для виходу): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char c = keyInfo.KeyChar;
                Console.WriteLine();

                // Вихід, якщо натиснуто ESC
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ESC - Вихід з програми.");
                    Console.ResetColor();
                    break;
                }

                // Перевірка: введений символ має бути літерою або цифрою
                if (!char.IsLetterOrDigit(c))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: Введений символ не є буквою або цифрою!");
                    Console.ResetColor();
                    continue; // Повернення до введення нового символу
                }

                // Переведення у нижній регістр для регістронезалежного порівняння
                string cLower = c.ToString().ToLower();

                // Фільтрація рядків за умовою (порівняння у нижньому регістрі)
                var filtered = A.Where(s => s.ToLower().EndsWith(cLower)).ToList();

                // Обробка результатів
                if (filtered.Count == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Знайдено: {filtered.First()}");
                }
                else if (filtered.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нічого не знайдено :(");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: Знайдено більше одного збігу");
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Виникла помилка: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
