using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using EFPerformance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using static EFPerformance.AppDbContext;

AppDbContext _context = new();

#region Project only - buffering

//foreach (var post in _context.Posts)
//{
//    Console.WriteLine("Post: " + post.Title);
//}

//foreach (var postTitle in _context.Posts.Select(x => x.Title))
//{
//    Console.WriteLine("Post: " + postTitle);
//}
#endregion

#region resultset size
//var posts = _context.Posts
//    .Where(p => p.Title.StartsWith("P"))
//    .ToList();

//var posts = _context.Posts
//    .Where(p => p.Title.StartsWith("P"))
//    .Take(20)
//    .ToList();
#endregion

#region Cartesian explosion
//var posts = _context.Users
//                    .Include(x => x.Posts)
//                    .ThenInclude(X => X.Tags)
//                    .ToList();

//var posts = _context.Users.Include(x => x.Posts)
//                    .ThenInclude(X => X.Tags).AsSplitQuery().ToList();
#endregion

#region Lazy Loading
//foreach (var post in _context.Posts.ToList())
//{
//    foreach (var tag in post.Tags)
//    {
//        Console.WriteLine($"Post {post.Title}, Tags: {tag.Title}");
//    }
//}
#endregion

#region Buffering and streaming

//var buffering_posts = _context.Posts
//    .Where(p => p.Title.StartsWith("P"))
//    .ToList();

//var streaming_posts = _context.Posts
//    .Where(p => p.Title.StartsWith("P"))
//    .Skip(1)
//    .Take(20)
//    .ToList();

#endregion

#region Tracking, no-tracking and identity resolution
//var streaming_posts = _context.Posts
//    .Where(p => p.Title.StartsWith("P"))
//    .Skip(1)
//    .Take(20)
//    .AsNoTracking()
//    .ToList();
#endregion

#region Using SQL queries
int Id = 1;
//var result = _context.Database
//                     .SqlQuery<PostDto>($@"SELECT [p].[Id], [p].[Title]
//                                           FROM [Posts] AS [p]
//                                           where [p].Id = {Id}")
//                     .Where(x=>x.Id == 1)
//                     .ToList();

//var result_raw = _context.Database
//                     .SqlQueryRaw<PostDto>($@"SELECT {"[p].[Id], [p].[Title]"}
//                                              FROM [Posts] AS [p]
//                                              where [p].Id = @p0", Id)
//                     //.Where(x=>x.Id == 1)
//                     .ToList();
//foreach (var item in result)
//{
//    Console.WriteLine($"Post : {item.Title}");
//}
#endregion


#region Batching

//_context.Add(new Post { Title = "EF Core ...1", UserId = 1 });
//_context.Add(new Post { Title = "EF Core ...2", UserId = 1 });
//_context.SaveChanges();

#endregion


// Context Pooling
// Compiled Query
// 

#region Update / Delete

//foreach (var post in _context.Posts)
//{
//    post.Description = post.Description + "--100";
//}
//_context.SaveChanges();


//_context.Posts.ExecuteUpdate(s => s.SetProperty(e => e.Description, e => e.Description + "--100"));
#endregion


#region Parameters
//string p1 = "post1";
//string p2 = "post2";
//var post1 = _context.Posts.FirstOrDefault(p => p.Title == p1 );
//var post2 = _context.Posts.FirstOrDefault(p => p.Title == p2);
#endregion

//Console.ReadLine();

//public class PostDto
//{
//    public int Id { get; set; }
//    public string Title { get; set; }
//}

BenchmarkRunner.Run(typeof(Program).Assembly);

// benchmark your code in several environments at once

// view the relative performance of your benchmarks

// In this attribute, you can specify a set of values
public class IntroParams
    {
        [Params(100, 200)]
        public int A { get; set; }

        [Benchmark]
        public void Benchmark()
        {
            Thread.Sleep(A + 5);
        }
    }


// will be executed only once per a benchmarked method
public class IntroSetupCleanupGlobal
{
    [Params(10, 100, 1000)]
    public int N;

    private int[] data;

    [GlobalSetup]
    public void GlobalSetup()
    {
        data = new int[N]; // executed once per each N value
    }
}

