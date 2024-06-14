//using EFPerformance;
//using Microsoft.EntityFrameworkCore;
//using System;

//AppDbContext _context = new();

//#region Project only - buffering

////foreach (var post in _context.Posts)
////{
////    Console.WriteLine("Post: " + post.Title);
////}

////foreach (var postTitle in _context.Posts.Select(x => x.Title))
////{
////    Console.WriteLine("Post: " + postTitle);
////}
//#endregion

//#region resultset size
////var posts = _context.Posts
////    .Where(p => p.Title.StartsWith("P"))
////    .ToList();

////var posts = _context.Posts
////    .Where(p => p.Title.StartsWith("P"))
////    .Take(20)
////    .ToList();
//#endregion

//#region Cartesian explosion
//var posts = _context.Users
//                    .Include(x => x.Posts)
//                    .ThenInclude(X=>X.Tags)
//                    .ToList();

////var posts = _context.Users.Include(x => x.Posts).AsSplitQuery().ToList();
//#endregion

//#region Lazy Loading
////foreach (var post in _context.Posts.ToList())
////{
////    foreach (var tag in post.Tags)
////    {
////        Console.WriteLine($"Post {post.Title}, Tags: {tag.Title}");
////    }
////}
//#endregion

//#region Buffering and streaming

////var buffering_posts = _context.Posts
////    .Where(p => p.Title.StartsWith("P"))
////    .ToList();

////var streaming_posts = _context.Posts
////    .Where(p => p.Title.StartsWith("P"))
////    .Skip(1)
////    .Take(20)
////    .ToList();

//#endregion

//#region Tracking, no-tracking and identity resolution
////var streaming_posts = _context.Posts
////    .Where(p => p.Title.StartsWith("P"))
////    .Skip(1)
////    .Take(20)
////    .AsNoTracking()
////    .ToList();

//#endregion

//#region Using SQL queries
////int Id = 1;
////var result = _context.Database
////                     .SqlQuery<PostDto>($@"SELECT [p].[Id], [p].[Title]
////                                           FROM [Posts] AS [p]
////                                           where [p].Id = {Id}")
////                     //.Where(x=>x.Id == 1)
////                     .ToList();

////var result_raw = _context.Database
////                     .SqlQueryRaw<PostDto>($@"SELECT {"[p].[Id], [p].[Title]"}
////                                              FROM [Posts] AS [p]
////                                              where [p].Id = @p0",Id)
////                     //.Where(x=>x.Id == 1)
////                     .ToList();
////foreach (var item in result)
////{
////    Console.WriteLine($"Post : {item.Title}");
////}
//#endregion
//Console.ReadLine();

//public class PostDto
//{
//    public int Id { get; set; }
//    public string Title { get; set; }
//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class LogParser
{
    internal static readonly string[] separator = ["   at "];

    public static void ErrorHandler(string logFilePath)
    {

        var logLines = File.ReadAllLines(logFilePath);
        string errorLinePattern = @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d+ \[TH=\d+\] ERROR (.*)";
        string stackTracePattern = @"^\s+at\s+.*";

        string errorMessage = logLines.FirstOrDefault(line => Regex.IsMatch(line, errorLinePattern));
        var stackTraceLines = logLines
            .SkipWhile(line => !Regex.IsMatch(line, errorLinePattern))
            .Skip(1)
            .TakeWhile(line => Regex.IsMatch(line, stackTracePattern))
            .ToList();

        string functionThrowingException = stackTraceLines
            .FirstOrDefault()?
            .Split(separator: ["   at "], StringSplitOptions.None)[1]
            .Split('(')[0];

        string rootCausePattern = @"WARN Unable to load";
        var rootCauseLines = logLines
            .Where(line => Regex.IsMatch(line, rootCausePattern))
            .ToList();

        Console.WriteLine("Error Message:");
        Console.WriteLine(errorMessage);
        Console.WriteLine();

        Console.WriteLine("Stack Trace:");
        stackTraceLines.ForEach(Console.WriteLine);
        Console.WriteLine();

        Console.WriteLine("Function Throwing the Exception:");
        Console.WriteLine(functionThrowingException);
        Console.WriteLine();

        Console.WriteLine("Potential Root Cause:");
        rootCauseLines.ForEach(Console.WriteLine);
    }
}
