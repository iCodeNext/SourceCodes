using System;
using System.Collections.Generic;

public class TreeDecrements
{
    public static int GetMinCost(int t_nodes, int[] t_from, int[] t_to, int[] val)
    {
        List<int>[] adj = new List<int>[t_nodes + 1];
        for (int i = 1; i <= t_nodes; i++)
        {
            adj[i] = new List<int>();
        }
        for (int i = 0; i < t_from.Length; i++)
        {
            adj[t_from[i]].Add(t_to[i]);
            adj[t_to[i]].Add(t_from[i]);
        }

        int[] subtreeSum = new int[t_nodes + 1];
        bool[] visited = new bool[t_nodes + 1];
        return DFS(1, adj, val, subtreeSum, visited);
    }

    private static int DFS(int node, List<int>[] adj, int[] val, int[] subtreeSum, bool[] visited)
    {
        visited[node] = true;
        int totalCost = 0;

        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                totalCost += DFS(neighbor, adj, val, subtreeSum, visited);
                subtreeSum[node] += subtreeSum[neighbor];
                totalCost += Math.Abs(subtreeSum[neighbor]);
            }
        }

        subtreeSum[node] += val[node - 1];
        return totalCost;
    }

    public static void Main(string[] args)
    {
        // Sample Input
        int t_nodes = 5;
        int[] t_from = { 1, 1, 3, 5 };
        int[] t_to = { 2, 3, 4, 5 };
        int[] val = { 3, 2, 4, 2, 5 };

        // Function Call
        int result = GetMinCost(t_nodes, t_from, t_to, val);
        Console.WriteLine(result); // Expected Output: 2
    }
}
