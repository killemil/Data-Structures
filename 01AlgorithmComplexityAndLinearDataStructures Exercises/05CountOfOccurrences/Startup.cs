namespace _05CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var result = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var counter = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                    }
                }

                if (!result.ContainsKey(numbers[i]))
                {
                    result[numbers[i]] = counter;
                }
            }

            foreach (var item in result.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value} times");
            }
        }
    }
}
