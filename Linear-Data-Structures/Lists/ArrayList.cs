using System;

public class ArrayList<T>
{
    private T[] array;

    public ArrayList(int capacity = 2)
    {
        this.array = new T[capacity];
        this.Capacity = capacity;
    }

    private int Capacity { get; set; }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.array[index];
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

    public void Add(T item)
    {
        if (this.Count  + 1 > this.Capacity)
        {
            this.Grow();
        }

        this.array[this.Count] = item;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        T item = this[index];
        this.array[index] = default(T);
        this.ShiftLeft(index);

        if (this.Count - 1 < this.Capacity / 4)
        {
            this.Shrink();
        }

        this.Count--;
        return item;
    }

    private void Grow()
    {
        T[] newArr = new T[this.Capacity * 2];
        this.Capacity *= 2;
        Array.Copy(this.array, newArr, this.Count);
        this.array = newArr;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.array[i] = this.array[i + 1];
        }
    }

    private void Shrink()
    {
        T[] newArr = new T[this.Capacity / 2];
        this.Capacity /= 2;
        Array.Copy(this.array, newArr, this.Count);
        this.array = newArr;
    }
}
