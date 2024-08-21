ListOfInt myList = new ListOfInt();

foreach (var item in myList)
{
    Console.WriteLine(item);
}

//var enumerator = myList.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    var value = enumerator.Current;
//    Console.WriteLine(value);
//}

List<int> ints = new List<int>();


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
public interface IEnumerator<T> : IEnumerator , IDisposable
{
    T Current { get; }
}
