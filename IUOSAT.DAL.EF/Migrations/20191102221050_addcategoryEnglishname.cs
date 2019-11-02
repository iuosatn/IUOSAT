using Microsoft.EntityFrameworkCore.Migrations;

namespace IUOSAT.DAL.EF.Migrations
{
    public partial class addcategoryEnglishname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "PersianName");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PersianName",
                table: "Categories",
                newName: "Name");
        }
    }
}
