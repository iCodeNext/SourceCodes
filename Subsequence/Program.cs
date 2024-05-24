



using System.ComponentModel.DataAnnotations;

class Result
{
    public static List<int> getMaxSubsequenceLen(List<int> arr)
    {
        List<int> result = [];
        arr.Sort();
        for (int i = 0; i < arr.Count; i++)
            result.Add(GetLongestSubsequence(arr, arr[i], i));
        return result;
    }

    private static int GetLongestSubsequence(List<int> arr, int median, int index)
    {
        List<int> lessThanMedian = [];
        List<int> greaterThanMedian = [];
        List<int> medianList = [];
        for (int i = 0; i < arr.Count ; i++)
        {
            if (i == index)
                continue;
            if (i < index && arr[i] < median)
                lessThanMedian.Add(arr[i]);
            else if (i > index && arr[i] > median)
                greaterThanMedian.Add(arr[i]);
        }

        int minimumDistinct = Math.Min(lessThanMedian.Distinct().Count(), greaterThanMedian.Distinct().Count());
        int arrayLengthBalance = Math.Min(lessThanMedian.Count, greaterThanMedian.Count);


        List<int> result = [.. GetSubsequenceList(lessThanMedian, arrayLengthBalance, minimumDistinct),
            median,
            .. GetSubsequenceList(greaterThanMedian, arrayLengthBalance, minimumDistinct)];


        return result.Count % 2 == 0 ? result.Count - 1 : result.Count;
    }

    private static List<int> GetSubsequenceList(List<int> arr, int length, int minimumDistinct)
    {
        if (arr.Count == 0 || length == 0)
            return [];


        var frequencyDict = arr.GroupBy(n => n)
                               .ToDictionary(g => g.Key, g => g.Count());

        var topFrequentNumbers = frequencyDict.OrderByDescending(x => x.Value)
                                              .ThenBy(x => arr.IndexOf(x.Key))
                                              .Select(x => x.Key)
                                              .Take(minimumDistinct)
                                              .ToList();
        List<int> result = topFrequentNumbers;



        foreach (var item in arr)
        {
            if (result.Contains(item)
                && frequencyDict[item] > result.Where(x => x == item).Count()
                && result.Count < length)
            {
                result.Add(item);
            }
        }

        return result;
    }
}

//miolsoft

class Solution
{
    public static void Main(string[] args)
    {


        List<int> result = Result.getMaxSubsequenceLen([1, 3, 2, 1, 3]);

        // Console.WriteLine(String.Join("\n", result));
        // Console.WriteLine();
        Console.Read();
    }
}
