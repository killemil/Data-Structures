namespace _04RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                var counter = 0;
                var currentNumber = numbers[i];
                for (int j = 0; j < numbers.Count; j++)
                {
                    var nextNumber = numbers[j];

                    if (currentNumber == nextNumber)
                    {
                        counter++;
                    }
                }

                if (counter % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
