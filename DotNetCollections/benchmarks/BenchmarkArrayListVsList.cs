using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections;
using System.Collections.Generic;

namespace DotNetCollections;

[MemoryDiagnoser]
public class ListVsArrayListBenchmark
{
    private const int NumberOfElements = 10000;

    [Benchmark]
    public void ArrayList_Add()
    {
        var arrayList = new ArrayList();
        for (int i = 0; i < NumberOfElements; i++)
        {
            arrayList.Add(i);
        }
    }

    [Benchmark]
    public void List_Add()
    {
        var list = new List<int>();
        for (int i = 0; i < NumberOfElements; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void ArrayList_Access()
    {
        var arrayList = new ArrayList();
        for (int i = 0; i < NumberOfElements; i++)
        {
            arrayList.Add(i);
        }

        for (int i = 0; i < NumberOfElements; i++)
        {
            int value = (int)arrayList[i];
        }
    }

    [Benchmark]
    public void List_Access()
    {
        var list = new List<int>();
        for (int i = 0; i < NumberOfElements; i++)
        {
            list.Add(i);
        }

        for (int i = 0; i < NumberOfElements; i++)
        {
            int value = list[i];
        }
    }
}
