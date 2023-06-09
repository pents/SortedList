namespace Pents.SortedList.Abstractions;

public interface ISortedList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    T? this[int index] { get; }
    void Add(T value);
    void Remove(T value);
}