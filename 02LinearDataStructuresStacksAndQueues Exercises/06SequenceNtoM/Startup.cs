namespace _06SequenceNtoM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = numbers[0];
            int end = numbers[1];

            if (end < start)
            {
                return;
            }

            Queue<Item> queue = new Queue<Item>();
            queue.Enqueue(new Item(start));

            while (true)
            {
                Item current = queue.Dequeue();

                if (current.Value == end)
                {
                    PrintSequence(current);
                    return;
                }
                else if (current.Value > end)
                {
                    continue;
                }

                queue.Enqueue(new Item(current.Value + 1, current));
                queue.Enqueue(new Item(current.Value + 2, current));
                queue.Enqueue(new Item(current.Value * 2, current));
            }

        }

        private static void PrintSequence(Item start)
        {
            LinkedList<int> list = new LinkedList<int>();
            Item current = start;

            while (current != null)
            {
                list.AddFirst(current.Value);
                current = current.Previous;
            }

            Console.WriteLine(string.Join(" ->", list));
        }

        class Item
        {
            public Item(int value, Item previous = null)
            {
                this.Value = value;
                this.Previous = previous;
            }
            public int Value { get; set; }

            public Item Previous { get; set; }
        }
    }
}
