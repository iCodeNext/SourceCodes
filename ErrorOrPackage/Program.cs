
float Divide(int a, int b)
{
    if (b is 0)
    {
        throw new Exception("");
    }

    return a / b;
}


try
{
    var result = Divide(4, 0);

    Console.WriteLine(result); // 4
}
catch (Exception)
{
    Console.WriteLine("Error");
}

