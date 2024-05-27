using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{

    public class Person
    {
        public int Index { get; set; }
        public int Time { get; set; }
        public int Direction { get; set; }
    }

    public static List<int> getTimes(List<int> time, List<int> direction)
    {
        int n = time.Count;
        int[] result = new int[n];
        Queue<Person> enterQueue = new();
        Queue<Person> exitQueue = new();
        for (int i = 0; i < n; i++)
        {
            var person = new Person
            {
                Index = i,
                Time = time[i],
                Direction = direction[i]
            };

            if (direction[i] == 0)
            {
                enterQueue.Enqueue(person);
            }
            else
            {
                exitQueue.Enqueue(person);
            }
        }

        int currentTime = 0;
        int lastUsed = -1;

        while (exitQueue.Count > 0 || enterQueue.Count > 0)
        {
            bool isEntered = false;
            bool isExited = false;

            if (exitQueue.Count > 0 &&
                 exitQueue.Peek().Time <= currentTime &&
                (lastUsed == 1 || lastUsed == -1 || enterQueue.Count == 0 || exitQueue.Peek().Time < enterQueue.Peek().Time))
            {
                var person = exitQueue.Dequeue();
                result[person.Index] = currentTime;
                lastUsed = 1;
                currentTime++;
                isExited = true;
            }
            else if (enterQueue.Count > 0 &&
                 enterQueue.Peek().Time <= currentTime &&
                 (lastUsed == 0 || lastUsed == -1 || exitQueue.Count == 0 || enterQueue.Peek().Time < exitQueue.Peek().Time))
            {
                var person = enterQueue.Dequeue();
                result[person.Index] = currentTime;
                lastUsed = 0;
                currentTime++;
                isEntered = true;
            }

            if (!isEntered && !isExited)
            {
                currentTime = Math.Min(enterQueue.Count > 0 ? enterQueue.Peek().Time : int.MaxValue, exitQueue.Count > 0 ? exitQueue.Peek().Time : int.MaxValue);
            }
            else
                currentTime++;

        }

        return result.ToList();
    }



}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> result = Result.getTimes([0, 0, 1, 5, 9, 900, 1000000000], [0, 1, 1, 0, 1, 0, 1]);


    }
}
