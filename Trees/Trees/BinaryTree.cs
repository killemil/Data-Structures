using System;

public class BinaryTree<T>
{
    private T value;
    private BinaryTree<T> leftChild;
    private BinaryTree<T> rightChild;

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
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

    public BinaryTree<T> LeftChild
    {
        get
        {
            return this.leftChild;
        }
        set
        {
            this.leftChild = value;
        }
    }

    public BinaryTree<T> RightChild
    {
        get
        {
            return this.rightChild;
        }
        set
        {
            this.rightChild = value;
        }
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);

        if (this.LeftChild != null)
        {
            this.LeftChild.PrintIndentedPreOrder(indent + 2);
        }

        if (this.LeftChild != null)
        {
            this.RightChild.PrintIndentedPreOrder(indent + 2);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this, action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.EachPostOrder(this, action);
    }

    private void EachInOrder(BinaryTree<T> current, Action<T> action)
    {
        if (current == null)
        {
            return;
        }

        this.EachInOrder(current.LeftChild, action);
        action(current.Value);
        this.EachInOrder(current.RightChild, action);
    }

    private void EachPostOrder(BinaryTree<T> current, Action<T> action)
    {
        if (current == null)
        {
            return;
        }

        this.EachPostOrder(current.LeftChild, action);
        this.EachPostOrder(current.RightChild, action);
        action(current.Value);
    }
}
