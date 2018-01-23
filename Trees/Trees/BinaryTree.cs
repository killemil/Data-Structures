using System;

public class BinaryTree<T>
{
    private T value;
    private BinaryTree<T> leftChild;
    private BinaryTree<T> rightChild;

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.value = value;
        this.leftChild = leftChild;
        this.rightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        this.PrintIndentedPreOrder(this, indent);
    }

    private void PrintIndentedPreOrder(BinaryTree<T> node, int indent)
    {
        if (node == null)
        {
            return;
        }

        Console.WriteLine($"{new string(' ', indent)}{node.value}");
        this.PrintIndentedPreOrder(node.leftChild, indent + 2);
        this.PrintIndentedPreOrder(node.rightChild, indent + 2);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this, action);
    }

    private void EachInOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.leftChild, action);
        action(node.value);
        this.EachInOrder(node.rightChild, action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.EachPostOrder(this, action);
    }

    private void EachPostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachPostOrder(node.leftChild, action);
        this.EachPostOrder(node.rightChild, action);
        action(node.value);
    }
}
