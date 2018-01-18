using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"Sum={numbers.Sum()}; Average={numbers.Average():f2}");
    }
}
