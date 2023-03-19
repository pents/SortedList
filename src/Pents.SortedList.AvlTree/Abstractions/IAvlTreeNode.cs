namespace Pents.SortedList.Models.Abstractions;

/// <summary>
/// Marker interface of AVL Tree
/// </summary>
public interface IAvlTreeNode
{
    
}

public interface IAvlTreeNode<T> : IAvlTreeNode
    where T : IComparable<T>
{
    T Value { get; }
    IAvlTreeNode<T>? Left { get; }
    IAvlTreeNode<T>? Right { get; }
    IAvlTreeNode<T> Add(T value);
    IAvlTreeNode<T>? Remove(T value);
}