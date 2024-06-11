using EFPerformance;
using Microsoft.EntityFrameworkCore;

AppDbContext _context = new();

#region Project only

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




Console.ReadLine();