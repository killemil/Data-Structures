namespace _02SortWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split().ToList();

            Console.WriteLine(string.Join(" ", words.OrderBy(c => c)));
        }
    }
}
