using System.Text;

file class Result
{
    public static string MorganAndString(string a, string b)
    {
        int i = 0, j = 0;
        int n = a.Length, m = b.Length;
        StringBuilder result = new();

        while (i < n && j < m)
        {
            if (string.Compare(a[i..], b[j..]) <= 0)
            {
                result.Append(a[i]);
                i++;
            }
            else
            {
                result.Append(b[j]);
                j++;
            }
        }
        if (i < n)
            result.Append(a.AsSpan(i));
        if (j < m)
            result.Append(b.AsSpan(j));

        return result.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Your Line: ");
        int t = int.Parse(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            Console.WriteLine($"-------------------- {tItr + 1} Attempt --------------------");
            Console.Write($"Enter Your First Input: ");
            string a = Console.ReadLine();

            Console.Write($"Enter Your Second Input: ");
            string b = Console.ReadLine();

            string result = Result.MorganAndString(a, b);

            Console.Write($"{tItr + 1}th Result: ");
            Console.WriteLine(result);
        }
    }
}