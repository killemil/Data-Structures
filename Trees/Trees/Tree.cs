using System;
using System.Collections.Generic;

public class Tree<T>
{
    private T value;
    private IList<Tree<T>> children;

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = children;
    }

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public IList<Tree<T>> Children
    {
        get
        {
            return this.children;
        }
        set
        {
            this.children = value;
        }
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.value);

        foreach (var child in this.children)
        {
            child.Print(indent + 2);
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
        var result = new List<T>();

        this.DFS(this, result);

        return result;
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

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.children)
        {
            this.DFS(child, result);
        }

        result.Add(tree.value);
    }
}
