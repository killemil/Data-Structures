using System;

public class LinkedQueue<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var newTail = new QueueNode<T>(element);
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.head.Value;

        var newHead = this.head.NextNode;
        newHead.PrevNode = null;
        this.head = newHead;

        this.Count--;

        return element;

    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        var currentNode = this.head;
        int counter = 0;
        while (currentNode != null)
        {
            array[counter++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public QueueNode<T> NextNode { get; set; }

        public QueueNode<T> PrevNode { get; set; }
    }

}
public class Startup
{
    public static void Main()
    {
    }
}
