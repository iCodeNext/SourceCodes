using System.Collections;

//int[] ints = new int[4];
//int[] ints2 = new int[8];


//ArrayList arrayList = new ArrayList();
//arrayList.Add(1);
//arrayList.Add(6);
//arrayList.Add(3);
//arrayList.Add(2);

////arrayList.BinarySearch

//foreach (var item in arrayList)
//{

//    Console.WriteLine(item);
//}


//List<int> arrayList = new List<int>();

//arrayList.Add(1);
//arrayList.Add(3);
//arrayList.Add(2);















//using BenchmarkDotNet.Running;
//using DotNetCollections;

//public class Program
//{
//    static void Main(string[] args)
//    {
//        BenchmarkRunner.Run<ListVsArrayListBenchmark>();
//    }
//}


DotNetCollections.Queue<int> _queue = new DotNetCollections.Queue<int>();
_queue.Enqueue(10);
_queue.Enqueue(20);
_queue.Enqueue(30);
_queue.Enqueue(40);

_queue.Enqueue(50);
_queue.Enqueue(60);
_queue.Enqueue(70);
_queue.Enqueue(80);

_queue.Dequeue();
_queue.Enqueue(90);




foreach (var item in _queue)
{
    Console.WriteLine(item);
}
Console.ReadLine();