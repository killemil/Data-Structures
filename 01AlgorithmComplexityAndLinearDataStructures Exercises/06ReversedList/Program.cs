using System;
using System.Collections;
using System.Collections.Generic;

class ReversedList<T> : IEnumerable<T>
{

    private T[] array;

    public ReversedList(int capacity = 2)
    {
        this.array = new T[capacity];
        this.Capacity = capacity;
    }

    public int Capacity { get; private set; }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.array[(this.Count - 1) - index];
        }
        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.array[index] = value;
        }
    }

    public void Add(T element)
    {
        if (this.Count >= this.array.Length)
        {
            this.Grow();
        }

        this.array[this.Count] = element;
        this.Count++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.array[(this.Count - 1) - index];
        this.array[(this.Count - 1) - index] = default(T);

        this.Count--;
    }

    private void Grow()
    {
        this.Capacity *= 2;
        var newArr = new T[this.Capacity];
        Array.Copy(this.array, newArr, this.Count);
        this.array = newArr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return this.GetEnumerator();
    }
}

public class Program
{
    public static void Main()
    {
        var array = new ReversedList<int>();
        array.Add(5);
        array.Add(3);
        array.Add(10);
        array.Add(13);
        array.Add(12);
        array.Add(16);

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}

