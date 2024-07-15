using ErrorOr;

float Divide(
    int a, int b)
{
    if (b is 0)
    {
        throw new ArgumentException("");
    }

    return a / b;
}

//try
//{
var result = Divide(4, 2);
if (result.IsError)
{
    Console.WriteLine("Error");
}
else
    Console.WriteLine(result.Value);
//}
//catch (Exception)
//{
//    Console.WriteLine("Error");
//}
