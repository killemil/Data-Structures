﻿using System;
using System.Collections.Generic;
using System.Linq;

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

    public List<Tree<T>> Children { get; set; }

}

public class Startup
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();
        var root = GetRootNode();
        var deepest = FindDeepestNode(root);

        Console.WriteLine($"Deepest node: {deepest.Value}");
    }

    private static Tree<int> FindDeepestNode(Tree<int> root)
    {
        int maxLevel = 0;
        Tree<int> deepest = null;
        FindDeepestNode(root, 0, ref maxLevel, ref deepest);

        return deepest;
    }

    private static void FindDeepestNode(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
    {
        if (node == null)
        {
            return;
        }

        if (level > maxLevel)
        {
            maxLevel = level;
            deepest = node;
        }

        foreach (var child in node.Children)
        {
            FindDeepestNode(child, level + 1, ref maxLevel, ref deepest);
        }
    }

    static Tree<int> GetRootNode()
    {
        return nodeByValue.Values
            .FirstOrDefault(x => x.Parent == null);
    }

    static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            AddEdge(edge[0], edge[1]);
        }
    }

    static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }
}

