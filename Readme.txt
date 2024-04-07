git clone https://github.com/MicrosoftDocs/mslearn-persist-data-ef-core

cd mslearn-persist-data-ef-core
code .

dotnet build

-- 此命令将添加包含 EF Core SQLite 数据库提供程序及其所有依赖项的 NuGet 包，包括常见的 EF Core 服务。
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

-- 此命令添加 EF Core 工具所需的包。
dotnet add package Microsoft.EntityFrameworkCore.Design

-- 此命令将安装 dotnet ef，用于创建迁移和基架的工具。
dotnet tool install --global dotnet-ef

builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");
using ContosoPizza.Data;

-- 生成用于创建数据库表的迁移
1）dotnet ef migrations add InitialCreate --context PizzaContext

-- To undo this action, use 'ef migrations remove'
-- 应用 InitialCreate 迁移
-- 此命令应用迁移。 ContosoPizza.db 不存在，因此在项目目录中创建迁移。
2）dotnet ef database update --context PizzaContext

Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (22ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA journal_mode = 'wal';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "__EFMigrationsHistory" (
          "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
          "ProductVersion" TEXT NOT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20240229013426_InitialCreate'.
Applying migration '20240229013426_InitialCreate'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Sauces" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Sauces" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Pizzas" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Pizzas" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NULL,
          "SauceId" INTEGER NULL,
          CONSTRAINT "FK_Pizzas_Sauces_SauceId" FOREIGN KEY ("SauceId") REFERENCES "Sauces" ("Id")
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Toppings" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Toppings" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NULL,
          "PizzaId" INTEGER NULL,
          CONSTRAINT "FK_Toppings_Pizzas_PizzaId" FOREIGN KEY ("PizzaId") REFERENCES "Pizzas" ("Id")
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX "IX_Pizzas_SauceId" ON "Pizzas" ("SauceId");
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX "IX_Toppings_PizzaId" ON "Toppings" ("PizzaId");
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20240229013426_InitialCreate', '8.0.2');
Done.


3）生成用于创建数据库表的迁移，创建名为 ModelRevisions 的迁移：
dotnet ef migrations add ModelRevisions --context PizzaContext

4）应用 ModelRevisions 迁移：
dotnet ef database update --context PizzaContext

Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (17ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20240229015046_ModelRevisions'.
Applying migration '20240229015046_ModelRevisions'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DROP INDEX "IX_Toppings_PizzaId";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Toppings" ADD "Calories" TEXT NOT NULL DEFAULT '0.0';
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Sauces" ADD "IsVegan" INTEGER NOT NULL DEFAULT 0;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "PizzaTopping" (
          "PizzasId" INTEGER NOT NULL,
          "ToppingsId" INTEGER NOT NULL,
          CONSTRAINT "PK_PizzaTopping" PRIMARY KEY ("PizzasId", "ToppingsId"),
          CONSTRAINT "FK_PizzaTopping_Pizzas_PizzasId" FOREIGN KEY ("PizzasId") REFERENCES "Pizzas" ("Id") ON DELETE CASCADE,
          CONSTRAINT "FK_PizzaTopping_Toppings_ToppingsId" FOREIGN KEY ("ToppingsId") REFERENCES "Toppings" ("Id") ON DELETE CASCADE
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX "IX_PizzaTopping_ToppingsId" ON "PizzaTopping" ("ToppingsId");
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "ef_temp_Toppings" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Toppings" PRIMARY KEY AUTOINCREMENT,
          "Calories" TEXT NOT NULL,
          "Name" TEXT NOT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "ef_temp_Toppings" ("Id", "Calories", "Name")
      SELECT "Id", "Calories", IFNULL("Name", '')
      FROM "Toppings";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "ef_temp_Sauces" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Sauces" PRIMARY KEY AUTOINCREMENT,
          "IsVegan" INTEGER NOT NULL,
          "Name" TEXT NOT NULL
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "ef_temp_Sauces" ("Id", "IsVegan", "Name")
      SELECT "Id", "IsVegan", IFNULL("Name", '')
      FROM "Sauces";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "ef_temp_Pizzas" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Pizzas" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NOT NULL,
          "SauceId" INTEGER NULL,
          CONSTRAINT "FK_Pizzas_Sauces_SauceId" FOREIGN KEY ("SauceId") REFERENCES "Sauces" ("Id")
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "ef_temp_Pizzas" ("Id", "Name", "SauceId")
      SELECT "Id", IFNULL("Name", ''), "SauceId"
      FROM "Pizzas";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA foreign_keys = 0;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DROP TABLE "Toppings";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "ef_temp_Toppings" RENAME TO "Toppings";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DROP TABLE "Sauces";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "ef_temp_Sauces" RENAME TO "Sauces";
Done.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DROP TABLE "Pizzas";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "ef_temp_Pizzas" RENAME TO "Pizzas";
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA foreign_keys = 1;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE INDEX "IX_Pizzas_SauceId" ON "Pizzas" ("SauceId");
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20240229015046_ModelRevisions', '8.0.2');


dotnet run

-- 使用数据库来搭建代码基架：
dotnet ef dbcontext scaffold "Data Source=Promotions/Promotions.db" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models

Build started...
Build succeeded.
To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.



https://github.com/bigbluefox/MediaCenters.git

git init

git config --global --add safe.directory D:/Codes/Apps/MediaCenters

git add .

git commit -m "项目初始化"

git remote add origin https://github.com/bigbluefox/MediaCenters.git

git pull https://github.com/bigbluefox/MediaCenters.git

git config --global http.sslVerify false

git push --set-upstream origin master


git merge master --allow-unrelated-histories
git pull --allow-unrelated-histories

git pull --allow-unrelated-histories https://github.com/bigbluefox/MediaCenters.git

















