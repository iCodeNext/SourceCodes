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














 
using BenchmarkDotNet.Running;
using DotNetCollections;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ListVsArrayListBenchmark>();
    }
}