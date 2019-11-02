using Microsoft.EntityFrameworkCore.Migrations;

namespace IUOSAT.DAL.EF.Migrations
{
    public partial class addCommenttext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MarkShipped",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MarkShipped",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");
        }
    }
}
