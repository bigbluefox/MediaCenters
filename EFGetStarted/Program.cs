

// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, Blogging!");

{
    using var db = new BloggingContext();

    // Note: This sample requires the database to be created before running.
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create
    Console.WriteLine("Inserting a new blog");
    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
    db.SaveChanges();

    // Read
    Console.WriteLine("Querying for a blog");
    var blog = db.Blogs
        .OrderBy(b => b.BlogId)
        .First();

    // Update
    Console.WriteLine("Updating the blog and adding a post");
    blog.Url = "https://devblogs.microsoft.com/dotnet";
    blog.Posts.Add(
        new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
    db.SaveChanges();

    // Delete
    Console.WriteLine("Delete the blog");
    db.Remove(blog);
    db.SaveChanges();

    //Hello, Blogging!
    //Database path: C: \Users\lihai\AppData\Local\blogging.db.
    //Inserting a new blog
    //Querying for a blog
    //Updating the blog and adding a post
    //Delete the blog
    //Bye, Blogging!
}

Console.WriteLine("Bye, Blogging!");
Console.ReadKey();
