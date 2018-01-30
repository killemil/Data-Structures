using System;
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

        foreach (var node in FindSubtreesWithGivenSum(GetRootNode()))
        {
            PrintPreOrder(node);
            Console.WriteLine();
        }
    }

    private static void PrintPreOrder(Tree<int> node)
    {
        Console.Write(node.Value + " ");
        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }
    }

    private static List<Tree<int>> FindSubtreesWithGivenSum(Tree<int> root)
    {
        var targetSum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {targetSum}:");

        var roots = new List<Tree<int>>();

        var sum = DFS(root, targetSum, 0, roots);

        return roots;
    }

    private static int DFS(Tree<int> node, int targetSum, int current, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }

        current = node.Value;

        foreach (var child in node.Children)
        {
            current += DFS(child, targetSum, current, roots);
        }

        if (current == targetSum)
        {
            roots.Add(node);
        }

        return current;
    }

    private static void GetSubtree(Tree<int> node, List<int> result)
    {
        result.Add(node.Value);
        foreach (var child in node.Children)
        {
            GetSubtree(child, result);
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

