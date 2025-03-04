using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        List<string> keys = new List<string> { "a", "b", "c" };
        Dictionary<string, int> originalDict = new Dictionary<string, int>
        {
            { "x", 1 },
            { "y", 2 },
            { "z", 3 }
        };

        Dictionary<string, int> newDict = new Dictionary<string, int>();
        List<int> valuesList = originalDict.Values.ToList(); // Перетворюємо Values у List
        int index = 0;

        foreach (var key in keys)
        {
            if (index < valuesList.Count)
            {
                newDict[key] = valuesList[index];
                index++;
            }
        }

        string json = JsonConvert.SerializeObject(newDict, Formatting.Indented);
        File.WriteAllText("output.json", json);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Словник збережено у файл output.json:");
        Console.ResetColor();
        Console.WriteLine(json);
    }
}
