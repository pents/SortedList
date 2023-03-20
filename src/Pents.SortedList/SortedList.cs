using System.Collections;
using Pents.SortedList.Abstractions;
using Pents.SortedList.AvlTree.Extensions;
using Pents.SortedList.Models;
using Pents.SortedList.Models.Abstractions;

namespace Pents.SortedList;

public class SortedList<T> : ISortedList<T> where T : IComparable<T>
{
    private IAvlTreeNode<T>? _root;
    
    public T? this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");
            }

            var currentIndex = 0;
            return GetValueAtIndex(_root, index, ref currentIndex);
        }
    }
    public void Add(T value)
    {
        _root = _root == null 
            ? new AvlTreeNode<T>(value) 
            : _root.Add(value);
    }
    
    public void Remove(T value)
    {
        _root = _root?.Remove(value);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _root.InOrderTraversal().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    private T? GetValueAtIndex(IAvlTreeNode<T>? node, int index, ref int currentIndex)
    {
        if (node == null)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        var value = default(T);

        if (node.Left != null)
        {
            value = GetValueAtIndex(node.Left, index, ref currentIndex);
        }

        if (currentIndex == index)
        {
            return node.Value;
        }

        currentIndex++;

        if (node.Right != null)
        {
            value = GetValueAtIndex(node.Right, index, ref currentIndex);
        }

        return value;
    }
}