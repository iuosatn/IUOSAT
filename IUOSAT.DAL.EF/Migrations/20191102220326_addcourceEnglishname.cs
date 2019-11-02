using Microsoft.EntityFrameworkCore.Migrations;

namespace IUOSAT.DAL.EF.Migrations
{
    public partial class addcourceEnglishname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cources",
                newName: "PersianName");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Cources",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Cources");

            migrationBuilder.RenameColumn(
                name: "PersianName",
                table: "Cources",
                newName: "Name");
        }
    }
}
