dotnet build

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef

-- builder.Services.AddSqlite<ProductsContext>("Data Source=Db/Products.db");
-- using CRUD_Demo.Data;

dotnet ef migrations add InitialCreate --context ProductsContext

dotnet ef database update --context ProductsContext






