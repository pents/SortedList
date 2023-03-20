using Pents.SortedList.Models.Abstractions;

namespace Pents.SortedList.AvlTree.Extensions;

public static class AvlTreeExtensions
{
    public static IEnumerable<T> InOrderTraversal<T>(this IAvlTreeNode<T>? node) 
        where T : IComparable<T>
    {
        if (node == null)
        {
            yield break;
        }

        foreach (var value in InOrderTraversal(node.Left))
        {
            yield return value;
        }

        yield return node.Value;

        foreach (var value in InOrderTraversal(node.Right))
        {
            yield return value;
        }
    }
}