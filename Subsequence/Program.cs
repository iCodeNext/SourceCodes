
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class Solution
{
    private static readonly Dictionary<int, int> _subsequenceLengths = [];
    public static List<int> GetMaxSubsequenceLen(List<int> arr)
    {
        List<int> sortedArray = new(arr);
        sortedArray.Sort();

        for (int i = 0; i < sortedArray.Count; i++)
        {
            int medianValue = sortedArray[i];
            List<int> leftSubArray = sortedArray.Take(i).ToList();
            List<int> rightSubArray = sortedArray.Skip(i + 1).ToList();

            var leftDistinctCollection = new HashSet<int>(leftSubArray.Where(x => x != medianValue));
            var rightDistinctCollection = new HashSet<int>(rightSubArray.Where(x => x != medianValue));

            if (rightDistinctCollection.Count is 0 || leftDistinctCollection.Count is 0)
            {
                List<int> median = arr.Where(x => x == medianValue).ToList();
                UpdateSubsequenceLength(medianValue, median.Count);
            }
            else
            {
                if (leftSubArray.Count < rightSubArray.Count)
                    BalanceSubsequence(leftSubArray, rightSubArray, medianValue, leftDistinctCollection);
                else
                    BalanceSubsequence(rightSubArray, leftSubArray, medianValue, rightDistinctCollection);
            }
        }

        return arr.Select(item => _subsequenceLengths.TryGetValue(item, out int value) ? value : 0).ToList();
    }

    private static void BalanceSubsequence(List<int> smallerSubArray, List<int> largerSubArray, int medianValue, HashSet<int> distinctCollection)
    {
        int distinctCount = distinctCollection.Count;
        bool balancedArray = FindBalancedSubsequence(largerSubArray, medianValue, distinctCount, smallerSubArray.Count);
        if (balancedArray)
        {
            int length = smallerSubArray.Count * 2 + 1;
            UpdateSubsequenceLength(medianValue, length);
        }
        else
        {
            BalanceSubsequenceFallback(smallerSubArray, largerSubArray, medianValue, distinctCollection);
        }
    }

    private static void BalanceSubsequenceFallback(List<int> smallerSubArray, List<int> largerSubArray, int medianValue, HashSet<int> distinctCollection)
    {
        int maxDistinctCount = distinctCollection.Count;
        if (maxDistinctCount == 1)
        {
            int smallerSubArrayCount = smallerSubArray.Count;
            while (smallerSubArrayCount > 0)
            {
                smallerSubArrayCount--;
                bool balancedArray = FindBalancedSubsequence(largerSubArray, medianValue, maxDistinctCount, smallerSubArrayCount);
                if (balancedArray)
                {
                    var length = smallerSubArrayCount * 2 + 1;
                    UpdateSubsequenceLength(medianValue, length);
                    break;
                }
            }
        }
        else
        {
            while (maxDistinctCount > 0)
            {
                maxDistinctCount--;
                int allocation = distinctCollection.GroupBy(n => n)
                                                   .ToDictionary(g => g.Key, g => g.Count())
                                                   .OrderByDescending(x => x.Value)
                                                   .Take(maxDistinctCount)
                                                   .Sum(x => x.Value);
                bool balancedArray = FindBalancedSubsequence(largerSubArray, medianValue, maxDistinctCount, allocation);
                if (balancedArray)
                {
                    int length = allocation * 2 + 1;
                    UpdateSubsequenceLength(medianValue, length);
                    break;
                }
            }
        }
    }

    private static void UpdateSubsequenceLength(int key, int length)
    {
        length = length % 2 is 0 ? length - 1 : length;
        if (_subsequenceLengths.TryGetValue(key, out int currentLength))
        {
            if (currentLength < length)
                _subsequenceLengths[key] = length;
            return;
        }
        _subsequenceLengths.Add(key, length);
    }

    private static bool FindBalancedSubsequence(List<int> array, int medianValue, int distinctCount, int length)
    {
        var distinctElements = array.Where(x => x != medianValue).Distinct().Count();
        if (distinctElements < distinctCount)
            return false;

        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

        var topFrequentNumbers = frequencyDict
            .Where(x => x.Key != medianValue)
            .OrderByDescending(x => x.Value)
            .Select(x => x.Key)
            .Take(distinctCount)
            .ToList();

        var result = new List<int>(topFrequentNumbers);
        foreach (var num in array)
        {
            if ((topFrequentNumbers.Contains(num) || num == medianValue)
                && result.Count < length
                && result.Where(x => x == num).Count() < frequencyDict[num])
                result.Add(num);
        }

        return result.Count == length;
    }

    public static void Main(string[] args)
    {
        List<int> arr = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 6, 6, 6, 6 };
        var result = GetMaxSubsequenceLen(arr);

        Console.WriteLine("Result for arr: ");
        foreach (var num in result)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
