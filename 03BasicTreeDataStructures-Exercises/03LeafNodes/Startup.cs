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
        IList<int> result = new List<int>();
        var root = GetRootNode();
        FindLeafNodes(root, result);

        Console.WriteLine($"Leaf nodes: {string.Join(" ", result.OrderBy(a => a))}");
    }

    private static void FindLeafNodes(Tree<int> node, IList<int> result)
    {
        if (node.Children.Count == 0)
        {
            result.Add(node.Value);
        }
        else
        {
            foreach (var child in node.Children)
            {
                FindLeafNodes(child, result);
            }
        }
    }

    static void PrintTree(int indent = 0)
    {
        var rootNode = GetRootNode();
        PrintTree(rootNode, indent);
    }

    static void PrintTree(Tree<int> node, int indent)
    {

        Console.WriteLine(new string(' ', (2 * indent)) + node.Value);
        foreach (var child in node.Children)
        {
            PrintTree(child, indent + 1);
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

