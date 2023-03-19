using System.Collections;
using Pents.SortedList.Abstractions;
using Pents.SortedList.Models;
using Pents.SortedList.Models.Abstractions;
using Pents.SortedList.Models.Extensions;

namespace Pents.SortedList;

public class SortedList<T> : ISortedList<T> where T : IComparable<T>
{
    private IAvlTreeNode<T>? _root;

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
}