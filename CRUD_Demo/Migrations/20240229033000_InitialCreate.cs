using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Demo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apples",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "VARCHAR", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", nullable: true),
                    Brand = table.Column<string>(type: "VARCHAR", nullable: true),
                    PruchasePrice = table.Column<double>(type: "DOUBLE", nullable: true),
                    SellingPrice = table.Column<double>(type: "DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apples", x => x.Barcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apples");
        }
    }
}
