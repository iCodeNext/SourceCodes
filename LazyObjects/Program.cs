using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//public class ExpensiveClass
//{
//    public ExpensiveClass()
//    {
//        Thread.Sleep(10000);
//    }

//    public override string ToString()
//    {
//        return "Hello!";
//    }
//}

//public static class Program
//{
//    static Lazy<ExpensiveClass> expensiveClass;
//    static Program()
//    {
//        expensiveClass = new();
//    }

//    public static void Main()
//    {
//        Console.WriteLine(DateTime.Now);
//        Console.WriteLine(expensiveClass.Value.ToString());
//    }
//}


//public class Customer
//{
//    public string FirstName { get; set; }
//    public Lazy<IEnumerable<Address>> Adresses { get; set; }
//}

//public class Address
//{
//    public string City { get; set; }
//}

//public static class Program
//{
//    public static void Main()
//    {
//        var customer = GetCustomerById(10);

//        var condition = Random.Shared.Next(1, 100);
//        // condition = 100;

//        foreach (var item in customer.Adresses.Value)
//        {
//            Console.WriteLine(item.City);
//        }
//    }

//    static Customer GetCustomerById(int id)
//    {
//        //Query with out getting Address Obj
//        return new Customer();
//    }
//}



//public class ServiceA
//{
//    public void Do()
//    {

//    }
//}

//public class ServiceB
//{
//    public void Do()
//    {

//    }
//}


//public class ServiceC(ServiceA serviceA, Lazy<ServiceB> serviceB)
//{
//    public void Update()
//    {
//        serviceA.Do();
//    }

//    public void Notify()
//    {
//        serviceB.Value.Do();
//    }
//}










public class ExpensiveClass
{
    public ExpensiveClass()
    {
        Thread.Sleep(10000);
    }

    public override string ToString()
    {
        return "Hello!";
    }
}
public class LazyBenchmark
{
    private Lazy<ExpensiveClass> lazyInstance;
    private ExpensiveClass eagerInstance;

    public LazyBenchmark()
    {
        lazyInstance = new Lazy<ExpensiveClass>(() => new ExpensiveClass());
        eagerInstance = new ExpensiveClass();
    }

    [Benchmark]
    public void AccessLazyOnce()
    {
        var obj = lazyInstance.Value;
    }

  

    [Benchmark]
    public void AccessLazyMultipleTimes()
    {
        for (int i = 0; i < 1000; i++)
        {
            var obj = lazyInstance.Value;
        }
    }

    [Benchmark]
    public void AccessEagerMultipleTimes()
    {
        for (int i = 0; i < 1000; i++)
        {
            var obj = eagerInstance;
        }
    }
}


public class Program
{

    public static void Main()
    {

        BenchmarkRunner.Run<LazyBenchmark>();
    }
}