using CRUD_Demo.Data;
using CRUD_Demo.Models;
using Microsoft.AspNetCore.Builder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "Data Source=Db/Products.db"; // 设置 SQLite 数据库文件路径
builder.Services.AddSqlite<ProductsContext>(connectionString);

// https://blog.csdn.net/beichengwuyi/article/details/135522653
// Install-Package Microsoft.EntityFrameworkCore.Tools
// Install-Package Microsoft.EntityFrameworkCore.Sqlite

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, CRUD!");

{
    #region MyRegion
    //DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", Microsoft.Data.Sqlite.SqliteFactory.Instance);
    //DbProviderFactories.RegisterFactory("Microsoft.EntityFrameworkCore.Sqlite", SQLiteFactory.Instance);

    //DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.EntityFrameworkCore.Sqlite");

    //DbProviderFactory factory = DbProviderFactories.GetFactory("Microsoft.Data.Sqlite");

    //if (factory != null)
    //{
    //    var builder1 = factory.CreateCommand();

    //    try
    //    {
    //        builder1.Connection = connection;

    //        connection.Open();

    //        Console.WriteLine($"Database Name: {builder1.Connection.Database}");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error: {ex.Message}");
    //    }
    //    finally
    //    {
    //        connection.Close();
    //    }
    //}
    #endregion

    using Microsoft.Data.Sqlite.SqliteConnection connection = new SqliteConnection(connectionString);

    Console.WriteLine("SQLite 数据库名称： " + connection.ConnectionString);

    //connection.Open();

    //string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='sqlite_master'";
    //using (var command = new SqliteCommand(query, connection))
    //{
    //    using (var reader = command.ExecuteReader())
    //    {
    //        if (reader.Read())
    //        {
    //            string databaseName = reader.GetString(0);
    //            Console.WriteLine("SQLite 数据库名称： " + databaseName);
    //        }
    //    }
    //}

    //connection.Close();

    var connstring = connectionString;
    var idx = connstring.LastIndexOf('.');
    Console.WriteLine(idx);

    connstring = connstring[..idx];
    Console.WriteLine(connstring);

    var dbName = string.Empty;
    var connArr = connstring.Split('\\');
    if(connArr.Length > 1)
    {
        dbName = connArr[^1];
    }
    else
    {
        connArr = connstring.Split('/');
        if (connArr.Length > 1)
        {
            dbName = connArr[^1];
        }
    }

    Console.WriteLine(dbName);






}

{
    //try
    //{
    //    Apple item = new Apple()
    //    {
    //        Barcode = "B12345678",
    //        Brand = "Milky Way",
    //        Name = "Milk",
    //        PruchasePrice = 20.5,
    //        SellingPrice = 25.5
    //    };
    //    // Uncomment this line if you want to test the delete method
    //    //DeleteItem("B12345678");
    //    AddItem(item);
    //    //Uncomment this line if you want to test the update method
    //    //item.SellingPrice = 30;
    //    //UpdateItem(item);
    //    Console.WriteLine("Everything is Ok !");
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine(e.Message);
    //    if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
    //}
}



Console.WriteLine("Hello, CRUD!");
Console.ReadKey();

static void AddItem(Apple apple)
{
    using var db = new ProductsContext();
    db.Apples.Add(apple);
    db.SaveChanges();
}

//Delete the item
static void DeleteItem(string Barcode)
{
    using var db = new ProductsContext();
    var apple = db.Apples.Find(Barcode);
    if (apple == null) return;
    db.Apples.Remove(apple);
    db.SaveChanges();
}

//Update the price of the item
static void UpdateItem(Apple apple)
{
    using var db = new ProductsContext();
    db.Apples.Update(apple);
    db.SaveChanges();
}
