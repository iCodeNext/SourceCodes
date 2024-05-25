
using System;

//public class Solution
//{
//    public static List<int> GetMaxSubsequenceLen(List<int> arr)
//    {
//        List<int> sortedArray = [.. arr];
//        sortedArray.Sort();

//        Dictionary<int, int> subsequenceLength = [];

//        for (int i = 0; i < sortedArray.Count; i++)
//        {
//            int medianValue = sortedArray[i];
//            List<int> leftSubArray = sortedArray.Take(i).ToList();
//            List<int> rightSubArray = sortedArray.Skip(i + 1).ToList();
//            List<int> median = arr.Where(x => x == medianValue).ToList();

//            var leftDistinctCollection = new HashSet<int>(leftSubArray.Where(x => x != medianValue));
//            var rightDistinctCollection = new HashSet<int>(rightSubArray.Where(x => x != medianValue));

//            if (rightDistinctCollection.Count == 0 || leftDistinctCollection.Count == 0)
//            {
//                int length = median.Count % 2 == 0 ? median.Count - 1 : median.Count;
//                UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//            }
//            else if (leftSubArray.Count < rightSubArray.Count)
//            {
//                var leftDistinctCount = leftDistinctCollection.Count;
//                var balancedArray = FindBalanceSubcequence(rightSubArray, medianValue, leftDistinctCount, leftSubArray.Count);
//                if (balancedArray)
//                {
//                    var length = leftSubArray.Count * 2 + 1;
//                    length = length % 2 == 0 ? length - 1 : length;
//                    UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//                }
//                else
//                {
//                    var maxLeft = leftDistinctCount;
//                    while (maxLeft > 0)
//                    {
//                        maxLeft--;
//                        var allocation = CalculateMaxAllocation([.. leftDistinctCollection], maxLeft);
//                        balancedArray = FindBalanceSubcequence(rightSubArray, medianValue, maxLeft, allocation);
//                        if (balancedArray)
//                        {
//                            var length = allocation * 2 + 1;
//                            length = length % 2 == 0 ? length - 1 : length;
//                            UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//                        }
//                    }
//                }
//            }
//            else
//            {
//                var rightDistinctCount = rightDistinctCollection.Count;
//                var balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, rightDistinctCount, rightSubArray.Count);
//                if (balancedArray)
//                {
//                    var length = rightSubArray.Count * 2 + 1;
//                    length = length % 2 == 0 ? length - 1 : length;
//                    UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//                }
//                else
//                {
//                    var maxright = rightDistinctCount;
//                    while (maxright > 0)
//                    {
//                        maxright--;
//                        var allocation = CalculateMaxAllocation([.. rightDistinctCollection], maxright);
//                        balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, maxright, allocation);
//                        if (balancedArray)
//                        {
//                            var length = allocation * 2 + 1;
//                            length = length % 2 == 0 ? length - 1 : length;
//                            UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//                            break;
//                        }
//                    }
//                    if (rightDistinctCount == 1)
//                    {
//                        maxright = rightSubArray.Count;
//                        while (maxright > 0)
//                        {
//                            maxright--;
//                            balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, rightDistinctCount, maxright);
//                            if (balancedArray)
//                            {
//                                var length = maxright * 2 + 1;
//                                length = length % 2 == 0 ? length - 1 : length;
//                                UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
//                                break;
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        List<int> finalResult = arr.Select(item => subsequenceLength.ContainsKey(item) ? subsequenceLength[item] : 0).ToList();
//        return finalResult;

//    }

//    private static void UpdateSubsequenceLength(Dictionary<int, int> subsequenceLength, int key, int length)
//    {
//        if (subsequenceLength.TryGetValue(key, out int value))
//        {
//            if (value < length)
//                subsequenceLength[key] = length;
//        }
//        else
//            subsequenceLength.Add(key, length);
//    }

//    private static int CalculateMaxAllocation(List<int> array, int distinctCount)
//    {


//        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

//        var allocation = frequencyDict.OrderByDescending(x => x.Value)
//                                              .Select(x => x.Key)
//                                              .Take(distinctCount)
//                                              .Sum();
//        return allocation;
//    }

//    private static bool FindBalanceSubcequence(List<int> array, int medianValue, int distinctCount, int length)
//    {
//        var countOfDistinct = array.Where(x => x != medianValue).Distinct().Count();
//        if (countOfDistinct < distinctCount)
//            return false;

//        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

//        var topFrequentNumbers = frequencyDict.Where(x => x.Key != medianValue).OrderByDescending(x => x.Value)
//                                              .ThenBy(x => array.IndexOf(x.Key))
//                                              .Select(x => x.Key)
//                                              .Take(distinctCount)
//                                              .ToList();
//        var result = topFrequentNumbers;
//        foreach (var num in array)
//            if ((topFrequentNumbers.Contains(num) || num == medianValue) && result.Where(x => x == num).Count() < frequencyDict[num] && result.Count < length)
//                result.Add(num);

//        var firstAttempt = result.Count == length;

//        frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

//        topFrequentNumbers = frequencyDict.Where(x => x.Key != medianValue).OrderByDescending(x => x.Value)
//                                            .ThenBy(x => array.IndexOf(x.Key))
//                                            .Select(x => x.Key)
//                                            .Take(distinctCount)
//                                            .ToList();
//        result = topFrequentNumbers;
//        foreach (var num in array)
//            if ((topFrequentNumbers.Contains(num) || num == medianValue) && result.Where(x => x == num).Count() < frequencyDict[num] && result.Count < length)
//                result.Add(num);

//        return firstAttempt || (result.Count == length);

//    }

//    public static void Main(string[] args)
//    {
//        List<int> arr = [1, 2, 2, 3, 4, 4, 4, 5, 6, 6, 6, 6];
//        var result = GetMaxSubsequenceLen(arr);

//        Console.WriteLine("Result for arr: ");
//        foreach (var num in result)
//        {
//            Console.Write(num + " ");
//        }
//        Console.WriteLine();
//    }
//}

public class Solution
{
    public static List<int> GetMaxSubsequenceLen(List<int> arr)
    {
        List<int> sortedArray = new(arr);
        sortedArray.Sort();

        Dictionary<int, int> subsequenceLengths = [];

        for (int i = 0; i < sortedArray.Count; i++)
        {
            int medianValue = sortedArray[i];
            List<int> leftSubArray = sortedArray.Take(i).ToList();
            List<int> rightSubArray = sortedArray.Skip(i + 1).ToList();
            List<int> median = arr.Where(x => x == medianValue).ToList();

            var leftDistinctCollection = new HashSet<int>(leftSubArray.Where(x => x != medianValue));
            var rightDistinctCollection = new HashSet<int>(rightSubArray.Where(x => x != medianValue));

            if (rightDistinctCollection.Count == 0 || leftDistinctCollection.Count == 0)
            {
                int length = median.Count % 2 == 0 ? median.Count - 1 : median.Count;
                UpdateSubsequenceLength(subsequenceLengths, medianValue, length);
            }
            else
            {
                ProcessBalancedSubsequence(subsequenceLengths, medianValue, leftSubArray, rightSubArray, leftDistinctCollection, rightDistinctCollection);
            }
        }

        return arr.Select(item => subsequenceLengths.TryGetValue(item, out int value) ? value : 0).ToList();
    }

    private static void ProcessBalancedSubsequence(Dictionary<int, int> subsequenceLengths, int medianValue, List<int> leftSubArray, List<int> rightSubArray, HashSet<int> leftDistinctCollection, HashSet<int> rightDistinctCollection)
    {
        if (leftSubArray.Count < rightSubArray.Count)
            BalanceSubsequence(leftSubArray, rightSubArray, medianValue, leftDistinctCollection, subsequenceLengths);
        else
            BalanceSubsequence(rightSubArray, leftSubArray, medianValue, rightDistinctCollection, subsequenceLengths);
    }

    private static void BalanceSubsequence(List<int> smallerSubArray, List<int> largerSubArray, int medianValue, HashSet<int> distinctCollection, Dictionary<int, int> subsequenceLengths)
    {
        int distinctCount = distinctCollection.Count;
        bool balancedArray = FindBalancedSubsequence(largerSubArray, medianValue, distinctCount, smallerSubArray.Count);
        if (balancedArray)
        {
            int length = smallerSubArray.Count * 2 + 1;
            length = length % 2 == 0 ? length - 1 : length;
            UpdateSubsequenceLength(subsequenceLengths, medianValue, length);
        }
        else
        {
            BalanceSubsequenceFallback(smallerSubArray,largerSubArray, medianValue, distinctCollection, subsequenceLengths);
        }
    }

    private static void BalanceSubsequenceFallback(List<int> smallerSubArray, List<int> largerSubArray, int medianValue, HashSet<int> distinctCollection, Dictionary<int, int> subsequenceLengths)
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
                    length = length % 2 == 0 ? length - 1 : length;
                    UpdateSubsequenceLength(subsequenceLengths, medianValue, length);
                    break;
                }
            }
        }
        else
        {
            while (maxDistinctCount > 0)
            {
                maxDistinctCount--;
                int allocation = CalculateMaxAllocation(new List<int>(distinctCollection), maxDistinctCount);
                bool balancedArray = FindBalancedSubsequence(largerSubArray, medianValue, maxDistinctCount, allocation);
                if (balancedArray)
                {
                    int length = allocation * 2 + 1;
                    length = length % 2 == 0 ? length - 1 : length;
                    UpdateSubsequenceLength(subsequenceLengths, medianValue, length);
                    break;
                }
            }
        }

    }

    private static void UpdateSubsequenceLength(Dictionary<int, int> subsequenceLengths, int key, int length)
    {
        if (subsequenceLengths.TryGetValue(key, out int currentLength))
        {
            if (currentLength < length)
                subsequenceLengths[key] = length;
        }
        else
        {
            subsequenceLengths.Add(key, length);
        }
    }

    private static int CalculateMaxAllocation(List<int> array, int distinctCount)
    {
        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
        return frequencyDict.OrderByDescending(x => x.Value)
                            .Take(distinctCount)
                            .Sum(x => x.Value);
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
