using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Children { get; private set; }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);

        foreach (var child in this.Children)
        {
            child.Print(indent + 2);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
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
            result.Add(current.Value);
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children)
        {
            this.DFS(child, result);
        }

        result.Add(tree.Value);
    }
}


