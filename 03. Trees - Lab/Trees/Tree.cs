using System;
using System.Collections.Generic;

public class Tree<T>
{
    private T value;
    private IList<Tree<T>> children;

    public Tree(T value, params Tree<T>[] children)
    {
        this.value = value;
        this.children = new List<Tree<T>>();

        foreach (var child in children)
        {
            this.children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.value);
        foreach (var child in this.children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.value);

        foreach (var child in this.children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        IList<T> result = new List<T>();
        this.OrderDFS(this, result);

        return result;
    }

    private void OrderDFS(Tree<T> tree, IList<T> result)
    {
        foreach (var child in tree.children)
        {
            this.OrderDFS(child, result);
        }

        result.Add(tree.value);
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.value);
            foreach (var child in current.children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }
}
