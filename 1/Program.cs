using System;
using System.Collections.Generic;

class Program
{
    static int Josephus(int n)
    {
        List<int> people = new List<int>();
        for (int i = 1; i <= n; i++)
            people.Add(i);

        int index = 0;
        while (people.Count > 1)
        {
            index = (index + 1) % people.Count;
            people.RemoveAt(index);
        }
        return people[0];
    }

    static void Main()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nВведіть кількість людей: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            // Перевірка введеного числа
            if (!int.TryParse(input, out int n) || n <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введіть ціле число більше 1");
                Console.ResetColor();
                continue; // Повертаємось до наступного введення
            }

            // Вивід результату
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Остання людина: {Josephus(n)}");
            Console.ResetColor();
        }
    }
}
