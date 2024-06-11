using EFPerformance;
using Microsoft.EntityFrameworkCore;
using System;

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

//var posts = _context.Users.Include(x => x.Posts).ToList();
//var posts = _context.Users.Include(x => x.Posts).AsSplitQuery().ToList();
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
var result = _context.Database
                     .SqlQueryRaw<PostDto>($"SELECT [p].[Id], [p].[Title] FROM [Posts] AS [p]")
                     //.Where(x=>x.Id == 1)
                     .ToList();
foreach (var item in result)
{
    Console.WriteLine($"Post : {item.Title}");
}
#endregion
Console.ReadLine();

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
}