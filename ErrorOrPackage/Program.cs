using ErrorOr;

ErrorOr<float> Divide(int a, int b)
{
    if (b is 0)
    {
        return Error.Unexpected(description: "Cannot divide by zero");
    }

    return a / b;
}


var result = Divide(4, 0);
if (result.IsError)
{
    Console.WriteLine(result.FirstError.Description);
    return;
}
Console.WriteLine(result.Value * 2); // 4

