namespace _03LongestSubsequence
{
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

            var startIndex = 0;
            var count = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentCount > count)
                {
                    startIndex = i;
                    count = currentCount;
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(numbers[i + startIndex] + " ");
            }
        }
    }
}
