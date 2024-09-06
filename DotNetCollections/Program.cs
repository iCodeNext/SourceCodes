List<int> ints = new List<int>();

foreach (var item in ints)
{
    Console.WriteLine(item);
}

//var enumerator = myList.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    var value = enumerator.Current;
//    Console.WriteLine(value);
//}

public interface IEnumerable
{
    IEnumerator GetEnumerator();
}
public interface IEnumerable<T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}

public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}
public interface IEnumerator<T> : IEnumerator, IDisposable
{
    T Current { get; }
}

public interface ICollection : IEnumerable
{
    int Count { get; }
    void CopyTo(Array array, int index);
}

public interface IList : ICollection, IEnumerable
{
    object? this[int index] { get; set; }
    bool IsFixedSize { get; }
    bool IsReadOnly { get; }
    int Add(object? value);
    void Clear();
    bool Contains(object? value);
    int IndexOf(object? value);
    void Insert(int index, object? value);
    void Remove(object? value);
    void RemoveAt(int index);
}


public interface ICollection<T> : IEnumerable<T>, IEnumerable
{
    int Count { get; }
    bool IsReadOnly { get; }
    void Add(T item);
    void Clear();
    bool Contains(T item);
    void CopyTo(T[] array, int arrayIndex);
    bool Remove(T item);
}

public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    T this[int index] { get; set; }
    int IndexOf(T item);
    void Insert(int index, T item);
    void RemoveAt(int index);
}

public class ICodeNextCollection<T> : IReadOnlyList<T>
{
    public T this[int index] => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


//ICodeNextCollection<int> collections = new ICodeNextCollection<int>();

//if (!collections.IsReadOnly)
//{
//    collections.Add(5);
//}


//public interface IReadOnlyCollection<out T> : IEnumerable<T>, IEnumerable
//{
//    int Count { get; }
//}

//public interface IReadOnlyList<out T> : IReadOnlyCollection<T>,
//                                        IEnumerable<T>, IEnumerable
//{
//    T this[int index] { get; }
//}

