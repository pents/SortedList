namespace Pents.SortedList.Abstractions;

public interface ISortedList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    void Add(T value);
    void Remove(T value);
}