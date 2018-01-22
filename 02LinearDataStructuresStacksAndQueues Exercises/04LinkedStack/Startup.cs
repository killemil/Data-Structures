using System;

class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];

        var currentNode = this.firstNode;
        int counter = 0;
        while (currentNode != null)
        {
            arr[counter++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return arr;
    }

    private class Node<T>
    {

        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value { get; set; }

        public Node<T> NextNode { get; set; }
    }
}

public class Startup
{
    public static void Main()
    {
        LinkedStack<int> stack = new LinkedStack<int>();

        stack.Push(1);
        stack.Push(2);

        Console.WriteLine(string.Join(" ", stack.ToArray()));

    }
}

