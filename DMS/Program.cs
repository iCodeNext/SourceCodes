using System;
using System.Collections.Generic;

//public class DeliveryManagementSystem
//{
//    public static List<int> order(int cityNodes, int[] cityFrom, int[] cityTo, int company)
//    {
//        Dictionary<int, List<int>> adjList = [];
//        for (int i = 1; i <= cityNodes; i++)
//            adjList[i] = [];

//        for (int i = 0; i < cityFrom.Length; i++)
//        {
//            adjList[cityFrom[i]].Add(cityTo[i]);
//            adjList[cityTo[i]].Add(cityFrom[i]);
//        }

//        SortedDictionary<int, SortedSet<int>> sortedCities = [];
//        HashSet<int> visited = [];
//        var queue = new Queue<(int city, int distance)>();

//        queue.Enqueue((company, 0));
//        visited.Add(company);

//        while (queue.Count > 0)
//        {
//            var (currentCity, currentDistance) = queue.Dequeue();

//            if (!sortedCities.ContainsKey(currentDistance))
//                sortedCities[currentDistance] = [];

//            sortedCities[currentDistance].Add(currentCity);

//            foreach (var neighbor in adjList[currentCity])
//            {
//                if (visited.Contains(neighbor))
//                    continue;

//                visited.Add(neighbor);
//                queue.Enqueue((neighbor, currentDistance + 1));
//            }
//        }

//        List<int> result = [];
//        foreach (var distanceGroup in sortedCities.Values)
//            foreach (var city in distanceGroup)
//                if (city != company)
//                    result.Add(city);

//        return result;
//    }

//    public static void Main(string[] args)
//    {
//        // Sample Input
//        int cityNodes = 5;
//        int[] cityFrom = { 1, 1, 1, 2, 3 };
//        int[] cityTo = { 2, 5, 3, 4, 5 };
//        int company = 1;

//        // Call the order function
//        List<int> result = order(cityNodes, cityFrom, cityTo, company);

//        // Print the result
//        foreach (var city in result)
//        {
//            Console.WriteLine(city);
//        }
//    }
//}

