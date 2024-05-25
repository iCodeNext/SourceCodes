
using System;

public class Solution
{
    public static List<int> GetMaxSubsequenceLen(List<int> arr)
    {
        List<int> sortedArray = [.. arr];
        sortedArray.Sort();

        Dictionary<int, int> subsequenceLength = [];

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
                UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
            }
            else if (leftSubArray.Count < rightSubArray.Count)
            {
                var leftDistinctCount = leftDistinctCollection.Count;
                var balancedArray = FindBalanceSubcequence(rightSubArray, medianValue, leftDistinctCount, leftSubArray.Count);
                if (balancedArray)
                {
                    var length = leftSubArray.Count * 2 + 1;
                    length = length % 2 == 0 ? length - 1 : length;
                    UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
                }
                else
                {
                    var maxLeft = leftDistinctCount;
                    while (maxLeft > 0)
                    {
                        maxLeft--;
                        var allocation = CalculateMaxAllocation([.. leftDistinctCollection], maxLeft);
                        balancedArray = FindBalanceSubcequence(rightSubArray, medianValue, maxLeft, allocation);
                        if (balancedArray)
                        {
                            var length = allocation * 2 + 1;
                            length = length % 2 == 0 ? length - 1 : length;
                            UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
                        }
                    }
                }
            }
            else
            {
                var rightDistinctCount = rightDistinctCollection.Count;
                var balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, rightDistinctCount, rightSubArray.Count);
                if (balancedArray)
                {
                    var length = rightSubArray.Count * 2 + 1;
                    length = length % 2 == 0 ? length - 1 : length;
                    UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
                }
                else
                {
                    var maxright = rightDistinctCount;
                    while (maxright > 0)
                    {
                        maxright--;
                        var allocation = CalculateMaxAllocation([.. rightDistinctCollection], maxright);
                        balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, maxright, allocation);
                        if (balancedArray)
                        {
                            var length = allocation * 2 + 1;
                            length = length % 2 == 0 ? length - 1 : length;
                            UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
                            break;
                        }
                    }
                    if (rightDistinctCount == 1)
                    {
                        maxright = rightSubArray.Count;
                        while (maxright > 0)
                        {
                            maxright--;
                            balancedArray = FindBalanceSubcequence(leftSubArray, medianValue, rightDistinctCount, maxright);
                            if (balancedArray)
                            {
                                var length = maxright * 2 + 1;
                                length = length % 2 == 0 ? length - 1 : length;
                                UpdateSubsequenceLength(subsequenceLength, sortedArray[i], length);
                                break;
                            }
                        }
                    }
                }
            }
        }

        List<int> finalResult = arr.Select(item => subsequenceLength.ContainsKey(item) ? subsequenceLength[item] : 0).ToList();
        return finalResult;

    }

    private static void UpdateSubsequenceLength(Dictionary<int, int> subsequenceLength, int key, int length)
    {
        if (subsequenceLength.TryGetValue(key, out int value))
        {
            if (value < length)
                subsequenceLength[key] = length;
        }
        else
            subsequenceLength.Add(key, length);
    }

    private static int CalculateMaxAllocation(List<int> array, int distinctCount)
    {


        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

        var allocation = frequencyDict.OrderByDescending(x => x.Value)
                                              .Select(x => x.Key)
                                              .Take(distinctCount)
                                              .Sum();
        return allocation;
    }

    private static bool FindBalanceSubcequence(List<int> array, int medianValue, int distinctCount, int length)
    {
        var countOfDistinct = array.Where(x => x != medianValue).Distinct().Count();
        if (countOfDistinct < distinctCount)
            return false;

        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

        var topFrequentNumbers = frequencyDict.Where(x => x.Key != medianValue).OrderByDescending(x => x.Value)
                                              .ThenBy(x => array.IndexOf(x.Key))
                                              .Select(x => x.Key)
                                              .Take(distinctCount)
                                              .ToList();
        var result = topFrequentNumbers;
        foreach (var num in array)
            if ((topFrequentNumbers.Contains(num) || num == medianValue) && result.Where(x => x == num).Count() < frequencyDict[num] && result.Count < length)
                result.Add(num);

        var firstAttempt = result.Count == length;

        frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

        topFrequentNumbers = frequencyDict.Where(x => x.Key != medianValue).OrderByDescending(x => x.Value)
                                            .ThenBy(x => array.IndexOf(x.Key))
                                            .Select(x => x.Key)
                                            .Take(distinctCount)
                                            .ToList();
        result = topFrequentNumbers;
        foreach (var num in array)
            if ((topFrequentNumbers.Contains(num) || num == medianValue) && result.Where(x => x == num).Count() < frequencyDict[num] && result.Count < length)
                result.Add(num);

        return firstAttempt || (result.Count == length);

    }

    public static void Main(string[] args)
    {
        List<int> arr = [1, 2, 2, 3, 4, 4, 4, 5, 6, 6, 6, 6];
        var result = GetMaxSubsequenceLen(arr);

        Console.WriteLine("Result for arr: ");
        foreach (var num in result)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class Solution
//{
//    public static List<int> GetMaxSubsequenceLen(List<int> arr)
//    {
//        List<int> sortedArr = new List<int>(arr);
//        sortedArr.Sort();
//        Dictionary<int, int> subsequenceLength = new Dictionary<int, int>();

//        for (int i = 0; i < sortedArr.Count; i++)
//        {
//            int medianValue = sortedArr[i];
//            List<int> leftSubArray = sortedArr.Take(i).ToList();
//            List<int> rightSubArray = sortedArr.Skip(i + 1).ToList();
//            List<int> medianList = arr.Where(x => x == medianValue).ToList();

//            var leftDistinctCollection = new HashSet<int>(leftSubArray.Where(x => x != medianValue));
//            var rightDistinctCollection = new HashSet<int>(rightSubArray.Where(x => x != medianValue));

//            int length = medianList.Count % 2 == 0 ? medianList.Count - 1 : medianList.Count;

//            if (rightDistinctCollection.Count == 0 || leftDistinctCollection.Count == 0)
//            {
//                UpdateSubsequenceLength(subsequenceLength, medianValue, length);
//            }
//            else if (leftSubArray.Count < rightSubArray.Count)
//            {
//                ProcessSubArray(rightSubArray, medianValue, leftDistinctCollection.Count, leftSubArray.Count, subsequenceLength, sortedArr[i]);
//            }
//            else
//            {
//                ProcessSubArray(leftSubArray, medianValue, rightDistinctCollection.Count, rightSubArray.Count, subsequenceLength, sortedArr[i]);
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

//    private static void ProcessSubArray(List<int> subArray, int medianValue, int distinctCount, int subArrayCount, Dictionary<int, int> subsequenceLength, int originalValue)
//    {
//        bool balancedArray = IsBalancedSubsequencePossible(subArray, medianValue, distinctCount, subArrayCount);
//        if (balancedArray)
//        {
//            int length = subArrayCount * 2 + 1;
//            length = length % 2 == 0 ? length - 1 : length;
//            UpdateSubsequenceLength(subsequenceLength, originalValue, length);
//        }
//        else
//        {
//            int maxDistinct = distinctCount;
//            while (maxDistinct > 0)
//            {
//                maxDistinct--;
//                int allocation = CalculateMaxAllocation(subArray, maxDistinct);
//                balancedArray = IsBalancedSubsequencePossible(subArray, medianValue, maxDistinct, allocation);
//                if (balancedArray)
//                {
//                    int length = allocation * 2 + 1;
//                    length = length % 2 == 0 ? length - 1 : length;
//                    UpdateSubsequenceLength(subsequenceLength, originalValue, length);
//                    break;
//                }
//            }
//        }
//    }

//    private static int CalculateMaxAllocation(List<int> array, int distinctCount)
//    {
//        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
//        return frequencyDict.OrderByDescending(x => x.Value).Take(distinctCount).Sum(x => x.Key);
//    }

//    private static bool IsBalancedSubsequencePossible(List<int> array, int medianValue, int distinctCount, int length)
//    {
//        var frequencyDict = array.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
//        var topFrequentNumbers = frequencyDict.Where(x => x.Key != medianValue).OrderByDescending(x => x.Value).Select(x => x.Key).Take(distinctCount).ToList();
//        var result = new List<int>(topFrequentNumbers);

//        foreach (var num in array)
//            if ((topFrequentNumbers.Contains(num) || num == medianValue) && result.Count(x => x == num) < frequencyDict[num] && result.Count < length)
//                result.Add(num);

//        return result.Count == length;
//    }

//    public static void Main(string[] args)
//    {
//        List<int> arr = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 6, 6, 6, 6 };
//        var result = GetMaxSubsequenceLen(arr);

//        Console.WriteLine("Result for arr: ");
//        foreach (var num in result)
//        {
//            Console.Write(num + " ");
//        }
//        Console.WriteLine();
//    }
//}
