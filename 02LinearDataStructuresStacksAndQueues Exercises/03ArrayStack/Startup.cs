
using System;
using System.Collections.Generic;
using System.Linq;

class ArrayStack<T>
{
    private const int InitialCapacity = 16;

    private T[] elements;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.elements[this.Count - 1];
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        LinkedList<T> list = new LinkedList<T>();

        for (int i = 0; i < this.Count; i++)
        {
            list.AddFirst(this.elements[i]);
        }

        return list.ToArray();
    }

    private void Grow()
    {
        Array.Resize(ref this.elements, this.elements.Length * 2);
    }
}

public class Startup
{
    public static void Main()
    {
        ArrayStack<int> numbers = new ArrayStack<int>();

        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        numbers.Push(4);

        Console.WriteLine(string.Join(" ", numbers.ToArray()));

        Console.WriteLine(numbers.Pop());
        Console.WriteLine(string.Join(" ", numbers.ToArray()));

    }
}

