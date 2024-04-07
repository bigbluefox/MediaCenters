using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaCenters.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    Author = table.Column<string>(type: "VARCHAR (50)", nullable: true),
                    Source = table.Column<string>(type: "VARCHAR (50)", nullable: true),
                    Abstract = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Album = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Artist = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Duration = table.Column<int>(type: "VARCHAR (50)", nullable: true),
                    Size = table.Column<int>(type: "INTEGER", nullable: true),
                    Extension = table.Column<string>(type: "VARCHAR (8)", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    DirectoryName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    MD5 = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    SHA1 = table.Column<string>(type: "VARCHAR (160)", nullable: true),
                    CreationTime = table.Column<string>(type: "VARCHAR (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Size = table.Column<long>(type: "BIGINT", nullable: true),
                    Extension = table.Column<string>(type: "VARCHAR (8)", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    DirectoryName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    CreationTime = table.Column<string>(type: "VARCHAR (24)", nullable: true),
                    MD5 = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    SHA1 = table.Column<string>(type: "VARCHAR (160)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Size = table.Column<int>(type: "INTEGER", nullable: true),
                    Extension = table.Column<string>(type: "VARCHAR (8)", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    DirectoryName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    MD5 = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    SHA1 = table.Column<string>(type: "VARCHAR (160)", nullable: true),
                    CreationTime = table.Column<string>(type: "VARCHAR (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaTag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaID = table.Column<int>(type: "INTEGER", nullable: true),
                    TagID = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Album = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Artist = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Duration = table.Column<int>(type: "VARCHAR (50)", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Size = table.Column<long>(type: "BIGINT", nullable: true),
                    Extension = table.Column<string>(type: "VARCHAR (8)", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    DirectoryName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "VARCHAR (24)", nullable: true),
                    MD5 = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    SHA1 = table.Column<string>(type: "VARCHAR (160)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstname = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    lastname = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    phone = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    email = table.Column<string>(type: "VARCHAR (255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Title = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Duration = table.Column<int>(type: "VARCHAR (50)", nullable: true),
                    Size = table.Column<int>(type: "INTEGER", nullable: true),
                    Extension = table.Column<string>(type: "VARCHAR (8)", nullable: true),
                    ContentType = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    DirectoryName = table.Column<string>(type: "VARCHAR (255)", nullable: true),
                    MD5 = table.Column<string>(type: "VARCHAR (128)", nullable: true),
                    SHA1 = table.Column<string>(type: "VARCHAR (160)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "VARCHAR (24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id",
                table: "Article",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audio_Id",
                table: "Audio",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_Id",
                table: "Book",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_Id",
                table: "Image",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaTag_ID",
                table: "MediaTag",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medium_Id",
                table: "Medium",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ID",
                table: "Tags",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_id",
                table: "UserInfo",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_Id",
                table: "Video",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "MediaTag");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
