using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();

        var root = GetRootNode();
        var leafNodes = GetLeafNodes().Select(x => x.Value).ToList().OrderBy(x => x);
        var middleNodes = GetMiddleNodes().Select(x => x.Value).ToList().OrderBy(x => x);

        Console.WriteLine($"Printing Tree:");
        root.Print();
        Console.WriteLine($"Root node: {root.Value}");
        Console.WriteLine($"Leaf nodes: {string.Join(" ", leafNodes)}");
        Console.WriteLine($"Middle nodes: {string.Join(" ",middleNodes)}");
    }

    private static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            string[] edge = Console.ReadLine().Split();
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    private static IList<Tree<int>> GetMiddleNodes()
    {
        return nodeByValue.Values.Where(t => t.Parent != null && t.Children.Count != 0).ToList();
    }

    private static IList<Tree<int>> GetLeafNodes()
    {
        return nodeByValue.Values.Where(t => t.Children.Count == 0).ToList();
    }

    private static Tree<int> GetRootNode()
    {
        return nodeByValue.Values
            .FirstOrDefault(t => t.Parent == null);
    }

    private static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    private static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }
}
