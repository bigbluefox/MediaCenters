
using MediaCenters.Data;
using MediaCenters.Models;
using MediaCenters.Services;
using MediaCenters.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<MediaCenterContext>("Data Source=Data/MediaCenter.db");

builder.Services.AddScoped<Mediaervice>();
builder.Services.AddScoped<PictureService>();
builder.Services.AddScoped<AudioService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<VideoService>();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, MediaCenter!");
Console.WriteLine("");

{
    //Console.WriteLine(HashAlgorithmHelper.ComputeHash<MD5>("Hello World!"));
    //Console.WriteLine(FileHelper.GetMd5Hash("Hello World!"));

    //while (true)
    //{
    //    var stopwatch = Stopwatch.StartNew();

    //    // A
    //    for (int i = 0; i < 1000000; i++)
    //    {
    //        HashAlgorithmHelper.ComputeHash<MD5>("Hello World!");
    //    }

    //    Console.WriteLine($"A:{stopwatch.ElapsedMilliseconds:#000}");

    //    stopwatch = Stopwatch.StartNew();

    //    // B
    //    for (int i = 0; i < 1000000; i++)
    //    {
    //        FileHelper.GetMd5Hash("Hello World!");
    //    }

    //    Console.WriteLine($"B:{stopwatch.ElapsedMilliseconds:#000}");

    //    // C
    //    for (int i = 0; i < 1000000; i++)
    //    {
    //        FileHelper.GetMd5Hash("Hello World!");
    //    }

    //    Console.WriteLine($"B:{stopwatch.ElapsedMilliseconds:#000}");
    //}
}

{
    var path = @"E:\Downloads\4  软件编程基础\1-C#零基础教程-59P";
    path = @"E:\Music";
    //path = @"E:\Downloads";

    var di = new DirectoryInfo(path);

    List<Medium> list = new();

    using var db = new MediaCenterContext();

    Mediaervice mediaervice = new(db);
    mediaervice.FindMediaFile(di, ref list, "", 1);

    if (list.Count > 0)
    {
        mediaervice.AddMedias(list);
    }

}

Console.WriteLine("");

{
    using var db = new MediaCenterContext();

    Console.WriteLine($"Audios.Count：{db.Audios.Count()}");
    Console.WriteLine($"Books.Count：{db.Books.Count()}");
    Console.WriteLine($"Images.Count：{db.Pictures.Count()}");
    Console.WriteLine($"Videos.Count：{db.Videos.Count()}");
    Console.WriteLine($"Media.Count：{db.Media.Count()}");

}

Console.WriteLine("");
Console.WriteLine("Bye, MediaCenter!");
Console.ReadKey();

/*
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

 To undo this action, use 'ef migrations remove'

*/
