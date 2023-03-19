using System.Diagnostics;
using Pents.SortedList.Models.Abstractions;

namespace Pents.SortedList.Models;

/// <summary>
/// AVL tree node
/// </summary>
/// <typeparam name="T"></typeparam>
public class AvlTreeNode<T> : IAvlTreeNode<T> 
    where T : IComparable<T>
{
    public T Value { get; private set; }
    public IAvlTreeNode<T>? Left => _left;
    public IAvlTreeNode<T>? Right => _right;

    private AvlTreeNode<T>? _left;
    private AvlTreeNode<T>? _right;
    
    private int _height;
    private int BalanceFactor => (_left?._height ?? 0) - (_right?._height ?? 0);

    public AvlTreeNode(T value)
    {
        Value = value;
        _height = 1;
    }
    
    public IAvlTreeNode<T> Add(T value)
    {
        return AddInternal(value);
    }

    private AvlTreeNode<T> AddInternal(T value)
    {
        var comparison = value.CompareTo(Value);
        
        switch (comparison)
        {
            case < 0:
                _left = _left == null ? new AvlTreeNode<T>(value) : _left.AddInternal(value);
                break;
            case > 0:
                _right = _right == null ? new AvlTreeNode<T>(value) : _right.AddInternal(value);
                break;
            default:
                throw new ArgumentException("Value already exists in the list.");
        }

        return Balance();
    }

    public IAvlTreeNode<T>? Remove(T value)
    {
        return RemoveInternal(value);
    }

    private AvlTreeNode<T>? RemoveInternal(T value)
    {
        var comparison = value.CompareTo(Value);
        switch (comparison)
        {
            case < 0:
                _left = _left?.RemoveInternal(value);
                break;
            case > 0:
                _right = _right?.RemoveInternal(value);
                break;
            default:
            {
                if (Left == null || Right == null)
                {
                    return _left ?? _right;
                }

                Debug.Assert(_right != null, nameof(_right) + " != null");
                var minValueNode = _right.GetMinValueNode();
                Value = minValueNode.Value;
                _right = _right.RemoveInternal(minValueNode.Value);
                break;
            }
        }

        return Balance();
    }

    private AvlTreeNode<T> RotateLeft()
    {
        var newRoot = _right;
        _right = newRoot!._left;
        newRoot._left = this;

        UpdateHeight();
        newRoot.UpdateHeight();

        return newRoot;
    }

    private AvlTreeNode<T> RotateRight()
    {
        var newRoot = _left;
        _left = newRoot!._right;
        newRoot._right = this;

        UpdateHeight();
        newRoot.UpdateHeight();

        return newRoot;
    }
    
    private AvlTreeNode<T> Balance()
    {
        UpdateHeight();

        switch (BalanceFactor)
        {
            case > 1:
            {
                if (_left?.BalanceFactor < 0)
                {
                    _left = _left.RotateLeft();
                }
                return RotateRight();
            }
            case < -1:
            {
                if (_right?.BalanceFactor > 0)
                {
                    _right = _right.RotateRight();
                }
                return RotateLeft();
            }
            default:
                return this;
        }
    }
    
    private AvlTreeNode<T> GetMinValueNode()
    {
        var node = this;
        while (node._left != null)
        {
            node = node._left;
        }
        return node;
    }

    private void UpdateHeight()
    {
        _height = 1 + Math.Max(
            _left?._height ?? 0, 
            _right?._height ?? 0);
    }
}