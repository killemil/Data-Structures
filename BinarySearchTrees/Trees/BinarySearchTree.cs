using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    public BinarySearchTree()
    {
    }

    private BinarySearchTree(Node node)
    {
        this.Copy(node);
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public void Insert(T element)
    {
        if (this.root == null)
        {
            this.root = new Node(element);
            return;
        }

        Node parrent = null;
        Node current = this.root;
        while (current != null)
        {
            parrent = current;
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        current = new Node(element);
        if (parrent.Value.CompareTo(element) < 0)
        {
            parrent.Right = current;
        }
        else
        {
            parrent.Left = current;
        }
    }

    public bool Contains(T element)
    {
        Node current = FindElement(element);

        return current != null;
    }

    private Node FindElement(T element)
    {
        Node current = this.root;
        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node current = this.root;
        Node parrent = null;
        while (current.Left != null)
        {
            parrent = current;
            current = current.Left;
        }

        if (parrent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parrent.Left = current.Right;
        }
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> range = new Queue<T>();

        this.Range(startRange, endRange, range, this.root);

        return range;
    }

    private void Range(T startRange, T endRange, Queue<T> range, Node node)
    {
        if (node == null)
        {
            return;
        }

        int compareLow = startRange.CompareTo(node.Value);
        int compareHigh = endRange.CompareTo(node.Value);

        if (compareLow < 0 )
        {
            this.Range(startRange, endRange, range, node.Left);
        }
        if (compareLow <= 0 && compareHigh >= 0)
        {
            range.Enqueue(node.Value);
        }
        if (compareHigh > 0)
        {
            this.Range(startRange, endRange, range, node.Right);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(12);
        bst.Insert(14);
        bst.Insert(5);
        bst.Insert(2);

        bst.EachInOrder(Console.WriteLine);
    }
}
