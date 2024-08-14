using System.Diagnostics;

Console.WriteLine("Hello, World!");

ListOfInt myList = new ListOfInt();

while (myList.MoveNext())
{
    var value = myList.Current;
    Console.WriteLine(value);
}

public interface IEnumerable
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}

public class ListOfInt : IEnumerable
{
    int[] _ints = [2, 3, 4, 5, 6];
    int _index = -1;

    public object Current => _ints[_index];

    public bool MoveNext()
    {
        if (_index++ < _ints.Length-1)
            return true;
        return false;
    }

    public void Reset()
    {
        _index = -1;
    }
}

 