namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var reversedNumbers = new Stack<int>(numbers);

            while (reversedNumbers.Count != 0)
            {
                Console.Write(reversedNumbers.Pop() + " ");
            }
        }
    }
}
