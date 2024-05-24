using System;
using System.Collections.Generic;

public class Program
{
    public static int DegreeOfArray(List<int> arr)
    {
        Dictionary<int, int> count = [];
        Dictionary<int, int> first = [];
        Dictionary<int, int> last = [];

        int degree = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            int num = arr[i];

            if (!count.TryGetValue(num, out int value))
            {
                value = 0;
                count[num] = value;
                first[num] = i;
            }

            count[num] = ++value;
            last[num] = i;
            degree = Math.Max(degree, value);
        }
        int minLength = arr.Count;

        foreach (var num in count.Keys)
        {
            if (count[num] == degree)
            {
                int length = last[num] - first[num] + 1;
                minLength = Math.Min(minLength, length);
            }
        }

        return minLength;
    }

    public static void Main(string[] args)
    {
        // Read input
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Call the function and print the result
        int result = DegreeOfArray(arr.ToList());
        Console.WriteLine(result);
    }
}
